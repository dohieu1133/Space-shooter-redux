using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image imageHealth;
    [SerializeField] Sprite[] number;
    [SerializeField] Text nameLevelText;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject gameClearPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject level;
    [SerializeField] string nextLevel;

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
        nameLevelText.text = SceneManager.GetActiveScene().name + "\nMove: w, a, s, d\nShoot: k";
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
            if (number[0] != null)
            {
                if (imageHealth != null)
                {
                    imageHealth.sprite = number[0];
                }
            }

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
    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void Pause()
    {
        if (pausePanel != null)
        {
            pausePanel.SetActive(true);
        }
        Time.timeScale = 0f;
    }
    public void Continue()
    {
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
        Time.timeScale = 1f;
    }
}
