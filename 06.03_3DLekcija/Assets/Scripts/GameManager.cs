using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Player player;
    public Character currentEnemy;

    public TMP_Text playerName;
    public TMP_Text playerHealth;
    public TMP_Text enemyName;
    public TMP_Text enemyHealth;
    public TMP_Text statusText;

    public GameObject attackButton;
    public GameObject shieldButton;

    public GameObject berserker;  // Reference to the Berserker GameObject
    public GameObject mage;       // Reference to the Mage GameObject
    public GameObject archer;     // Reference to the Archer GameObject

    public Image berserkerImage;  // UI Image for Berserker
    public Image mageImage;       // UI Image for Mage
    public Image archerImage;     // UI Image for Archer

    private int enemyIndex = 0;   // To keep track of which enemy is next

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        playerName.text = player.charName;
        playerHealth.text = "Health: " + player.health.ToString();
        statusText.text = "Battle Start!";
        SpawnNextEnemy();
    }

    public void Attack()
    {
        statusText.text = "You attacked!";
        currentEnemy.GetHit(player.Attack());
        UpdateUI();

        if (currentEnemy.health <= 0)
        {
            statusText.text = "Enemy defeated!";
            SpawnNextEnemy();  // Spawn the next enemy after the current one is defeated
        }
        else
        {
            // After the player's attack, let the enemy attack the player
            statusText.text = currentEnemy.characterName + " attacks!";
            player.GetHit(currentEnemy.Attack());  // Enemy attacks player
            UpdateUI();
        }
    }

    public void Defend()
    {
        statusText.text = "You are defending!";
        player.ActivateShield();
    }

    public void EndDefend()
    {
        statusText.text = "You stopped defending!";
        player.DeactivateShield();
    }

    public void UpdateUI()
    {
        playerHealth.text = "Health: " + player.health.ToString();
        enemyHealth.text = "Health: " + currentEnemy.health.ToString();
    }

    public void SpawnNextEnemy()
    {
        // Disable all enemy GameObjects
        berserker.SetActive(false);
        mage.SetActive(false);
        archer.SetActive(false);

        // Disable all enemy images
        berserkerImage.gameObject.SetActive(false);
        mageImage.gameObject.SetActive(false);
        archerImage.gameObject.SetActive(false);

        // Check if all enemies are defeated
        if (enemyIndex == 3)  // We have defeated all 3 enemies
        {
            EndGame();
            return;
        }

        // Based on enemyIndex, activate the next enemy and its image
        if (enemyIndex == 0)
        {
            berserker.SetActive(true);
            currentEnemy = berserker.GetComponent<Berserker>();
            berserkerImage.gameObject.SetActive(true);
        }
        else if (enemyIndex == 1)
        {
            mage.SetActive(true);
            currentEnemy = mage.GetComponent<Mage>();
            mageImage.gameObject.SetActive(true);
        }
        else if (enemyIndex == 2)
        {
            archer.SetActive(true);
            currentEnemy = archer.GetComponent<Archer>();
            archerImage.gameObject.SetActive(true);
        }

        // Update UI with new enemy's stats
        enemyName.text = currentEnemy.characterName;
        enemyHealth.text = "Health: " + currentEnemy.health.ToString();

        enemyIndex++;  // Increment enemyIndex after setting everything
    }

    public void EndGame()
    {
        statusText.text = "You Win!";
        attackButton.SetActive(false);
        shieldButton.SetActive(false);
    }
}




