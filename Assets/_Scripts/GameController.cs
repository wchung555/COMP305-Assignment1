// COMP305 Assignment 1 - completed by Winnie Chung

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    private int _score = 0;
    private int _lives = 10;
    private bool _isDoughnutPresent = false; // only one doughnut will appear per scene
    private int _currentEnemies = 0; // how many enemies have been spawned
    private int _enemiesPerLevel = 1; // max enemies to spawn

    [Header("Interactive Game Objects")]
    public Transform doughnut;
    public int scoreIncrease = 10; // score increase when doughnut is collected
    public Transform enemy;
    public int maxEnemies = 5;

    [Header("User Interface")]
    public Text scoreText;
    public int levelUp = 100; // score required to level up
    public Image livesImage;
    public Text livesText;

    // Use this for initialization
    void Start() {
        if (scoreIncrease <= 0) {
            scoreIncrease = 10;
        }

        if (levelUp <= 0) {
            levelUp = 100;
        }

        if (maxEnemies <= 0) {
            maxEnemies = 5;
        }
    }

    // Update is called once per frame
    void Update() {
        scoreText.text = "Score: " + this._score;
        livesText.text = "x " + this._lives;

        if (_lives < 10) {
            livesImage.rectTransform.position = new Vector2(834, 758);
        }
        else {
            livesImage.rectTransform.position = new Vector2(809, 758);
        }

        this._SpawnEnemies();
        this._SpawnDoughnut();
    }

    /// <summary>
    /// Decrease lives
    /// </summary>
    public void HitEnemy() {
        this._currentEnemies--;
        if (this._lives > 0) {
            this._lives--;
        }
    }

    /// <summary>
    /// Increase score, max enemies to spawn, and lives (if player levels up)
    /// </summary>
    public void GetDoughnut() {
        this._isDoughnutPresent = false;
        this._score += scoreIncrease;
        if (this._enemiesPerLevel < maxEnemies) {
            this._enemiesPerLevel++;
        }

        if (this._score % levelUp == 0 && this._lives < 10) {
            this._lives++;
        }
    }

    /// <summary>
    /// Create enemies
    /// </summary>
    private void _SpawnEnemies() {
        while (this._currentEnemies < this._enemiesPerLevel) {
            Instantiate(enemy);
            this._currentEnemies++;
        }
    }

    /// <summary>
    /// Create a doughnut
    /// </summary>
    private void _SpawnDoughnut() {
        if (!this._isDoughnutPresent) {
            Instantiate(doughnut);
            this._isDoughnutPresent = true;
        }
    }
}
