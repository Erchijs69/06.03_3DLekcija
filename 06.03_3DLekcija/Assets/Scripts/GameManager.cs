using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Player player;
    public Character enemy;

    public TMP_Text playerName;
    public TMP_Text playerHealth;
    public TMP_Text enemyName;
    public TMP_Text enemyHealth;
    public TMP_Text statusText;

    public GameObject attackButton;
    public GameObject shieldButton;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        playerName.text = player.charName;
        playerHealth.text = "Health: " + player.health.ToString();
        enemyName.text = enemy.characterName;
        enemyHealth.text = "Health: " + enemy.health.ToString();
        statusText.text = "Battle Start!";
    }

    public void Attack()
    {
        statusText.text = "You attacked!";
        enemy.GetHit(player.Attack());
        UpdateUI();
        if (enemy.health <= 0)
        {
            statusText.text = "You Win!";
            CreateNewEnemy();
        }
        else
        {
            int enemyDamage = enemy.Attack();
            player.GetHit(enemyDamage);  // Enemy attacks player
            UpdateUI();
        }
    }

    public void Defend()
    {
        statusText.text = "You are defending!";
        player.ActivateShield();  // Activate shield
    }

    public void EndDefend()
    {
        statusText.text = "You stopped defending!";
        player.DeactivateShield();  // Deactivate shield
    }

    public void UpdateUI()
    {
        playerHealth.text = "Health: " + player.health.ToString();
        enemyHealth.text = "Health: " + enemy.health.ToString();
    }

    public void CreateNewEnemy()
    {
        Debug.Log("A new enemy appears!");
        int enemyType = Random.Range(0, 3);
        switch (enemyType)
        {
            case 0:
                enemy = new Berserker();
                break;
            case 1:
                enemy = new Mage();
                break;
            case 2:
                enemy = new Archer();
                break;
        }
        enemyName.text = enemy.characterName;
        enemyHealth.text = "Health: " + enemy.health.ToString();
    }

    public void EndGame()
    {
        statusText.text = "Game Over!";
        attackButton.SetActive(false);
        shieldButton.SetActive(false);
    }
}


