using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image imageHealth;
    [SerializeField] Sprite[] number;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject gameClearPanel;
    [SerializeField] GameObject level;

    PlayerController player;
    int healthPlayer;

    private void Awake()
    {
        player = GameObject.Find("playerShip").GetComponent<PlayerController>();
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        if (gameClearPanel != null)
        {
            gameClearPanel.SetActive(false);
        }
    }
    private void Update()
    {
        if (level == null)
        {
            GameClear();
            return;
        }

        if (player != null)
        {
            healthPlayer = Mathf.Clamp(player.health, 0, number.Length - 1);
            if (number[healthPlayer] != null)
            {
                if (imageHealth != null)
                {
                    imageHealth.sprite = number[healthPlayer];
                }
            }
            if (healthPlayer == 0)
            {
                GameOver();
            }
        }
        else
        {
            GameOver();
        }
    }

    void GameOver()
    {
        if (gameOverPanel != null) 
        { 
            gameOverPanel.SetActive(true);
        }
    }
    void GameClear()
    {
        if (gameClearPanel != null)
        {
            gameClearPanel.SetActive(true);
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
