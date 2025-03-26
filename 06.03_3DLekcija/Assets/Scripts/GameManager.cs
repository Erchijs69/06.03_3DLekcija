using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Player player;
    public Character currentEnemy;

//TEXT
    public TMP_Text playerName;
    public TMP_Text playerHealth;
    public TMP_Text enemyName;
    public TMP_Text enemyHealth;
    public TMP_Text statusText;
//UI BUTTONS
    public GameObject attackButton;
    public GameObject shieldButton;
    public GameObject restartButton;
//ENEMIES
    public GameObject berserker;
    public GameObject mage;
    public GameObject archer;
//IMAGES
    public Image berserkerImage;
    public Image mageImage;
    public Image archerImage;

//AUDIO
    public AudioSource audioSource;
    public AudioClip attackSound;
    public AudioClip defendSound;
    public AudioClip buttonClickSound;
    public AudioClip shieldBreakSound;  

    private int enemyIndex = 0;
    private bool hasPlayedShieldBreakSound = false;  

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        playerName.text = player.charName;
        playerHealth.text = "Health: " + player.health.ToString();
        statusText.text = "Battle Start!";
        restartButton.SetActive(false);
        SpawnNextEnemy();
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public void Attack()
    {
        PlaySound(attackSound);
        int playerDamage = player.Attack();
        statusText.text = "You attacked!";
        Debug.Log($"Player attacks {currentEnemy.characterName} for {playerDamage} damage.");
        
        currentEnemy.GetHit(playerDamage);
        UpdateUI();

        if (currentEnemy.health <= 0)
        {
            Debug.Log($"{currentEnemy.characterName} defeated!");
            statusText.text = "Enemy defeated!";
            SpawnNextEnemy();
        }
        else
        {
            EnemyTurn();
        }
    }

    public void EnemyTurn()
    {
        int enemyDamage = currentEnemy.Attack();
        statusText.text = currentEnemy.characterName + " attacks!";
        Debug.Log($"{currentEnemy.characterName} attacks Player for {enemyDamage} damage.");
        
        player.GetHit(enemyDamage);
        UpdateUI();

        if (player.health <= 0)
        {
            EndGame(false);
        }
    }

    public void Defend()
    {
        PlaySound(defendSound);
        statusText.text = "You are defending!";
        Debug.Log("Player is defending.");
        player.ActivateShield();
    }

    public void EndDefend()
    {
        statusText.text = "You stopped defending!";
        Debug.Log("Player stopped defending.");
        player.DeactivateShield();
    }

   
    public void UpdateUI()
    {
        playerHealth.text = "Health: " + Mathf.Max(0, player.health).ToString();
        enemyHealth.text = "Health: " + Mathf.Max(0, currentEnemy.health).ToString();

        // Broken Sjield
        if (player.ShieldDurability <= 0 && player.IsShieldBroken && !hasPlayedShieldBreakSound)
        {
            shieldButton.SetActive(false);  // Disable shield button
            statusText.text = "Shield broken!";  // Update status text
            PlaySound(shieldBreakSound);  // Play shield break sound once
            hasPlayedShieldBreakSound = true;  // Mark the sound as played
        }
    }

    public void SpawnNextEnemy()
    {
        berserker.SetActive(false);
        mage.SetActive(false);
        archer.SetActive(false);

        berserkerImage.gameObject.SetActive(false);
        mageImage.gameObject.SetActive(false);
        archerImage.gameObject.SetActive(false);

        if (enemyIndex == 3)
        {
            EndGame(true);
            return;
        }

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

        Debug.Log($"New enemy spawned: {currentEnemy.characterName} with {currentEnemy.health} HP.");
        enemyName.text = currentEnemy.characterName;
        enemyHealth.text = "Health: " + currentEnemy.health.ToString();

        enemyIndex++;
    }

    public void EndGame(bool playerWon)
    {
        if (playerWon)
        {
            statusText.text = "You Win!";
            Debug.Log("Player won the battle!");
        }
        else
        {
            statusText.text = "You Lose!";
            Debug.Log("Player lost the battle!");
        }

        attackButton.SetActive(false);
        shieldButton.SetActive(false);
        restartButton.SetActive(true);
    }

    public void RestartGame()
    {
        PlaySound(buttonClickSound);
        Debug.Log("Restarting game...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


