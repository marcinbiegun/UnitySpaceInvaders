using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public static LevelManager instance = null;

    public int score = 0;
    public int damage = 0;
    public int lives = 3;

    public Text scoreText;
    public Text damageText;
    public Text livesText;
    public Text gameOverText;

    private void Start() {
        // Make self a publicly available singleton
        if (instance == null) { instance = this; } else if (instance != this) { Destroy(gameObject); }

        Setup();
    }

    void Setup() {
        Time.timeScale = 1f;
        UpdateUI();
        gameOverText.enabled = false;
    }

    void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void UpdateUI() {
        scoreText.text = "" + score;
        damageText.text = "" + damage;
        livesText.text = "" + lives;
    }

    public void GameOver() {
        gameOverText.enabled = true;
        Time.timeScale = 0f;
    }

    public void CityDamaged() {
        damage += 1;
        UpdateUI();
    }

    public void AlienKilled() {
        score += 100;
        UpdateUI();
    }

    public void PlayerDied() {
        lives -= 1;
        if (lives < 1)
            GameOver();
        UpdateUI();
    }

    public void ResetRequested() {
        if (lives < 1)
            ReloadScene();
    }
}
