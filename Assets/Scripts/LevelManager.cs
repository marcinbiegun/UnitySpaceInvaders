using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    public static LevelManager instance = null;

    public int score = 0;
    public int damage = 0;
    public int lives = 3;

    public Text scoreText;
    public Text damageText;
    public Text livesText;

    private void Start() {
        // Make self a publicly available singleton
        if (instance == null) { instance = this; } else if (instance != this) { Destroy(gameObject); }

        UpdateUI();
    }

    void BuildLevel() {
    }

    void DestroyLevel() {
    }

    void UpdateUI() {
        scoreText.text = "" + score;
        damageText.text = "" + damage;
        livesText.text = "" + lives;
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
        UpdateUI();
    }
}
