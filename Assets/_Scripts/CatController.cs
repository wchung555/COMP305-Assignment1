// COMP305 Assignment 1 - completed by Winnie Chung

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class CatController : MonoBehaviour {

    #region private instance variables
    private Transform _transform;
    private int _lives = 10;
    private int _score = 0;

    private Text _scoreText;
    private Text _livesText;
    #endregion

    // Use this for initialization
    void Start () {
        this._transform = this.GetComponent<Transform>();

        this._scoreText = GameObject.Find("Score Label").GetComponent<Text>();
        this._livesText = GameObject.Find("Lives Label").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        this._move();

        this._scoreText.text = "Score: " + this._score;
        this._livesText.text = "x " + this._lives;
    }

    /// <summary>
    /// Move the game controller vertically according to the mouse's movement
    /// </summary>
    private void _move() {
        this._transform.position = new Vector2(-270, Mathf.Clamp(Input.mousePosition.y - 240, -220, 220));
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("doughnut")) {
            Debug.Log("Doughnut hit!");
        }
        else if (other.gameObject.CompareTag("enemy")) {
            Debug.Log("Enemy hit!");
            this._lives--;
        }
        Destroy(other.gameObject);

        if (this._lives <= 0) {
            Debug.Log("Game over...");
            Destroy(this.gameObject);
        }
    }
}
