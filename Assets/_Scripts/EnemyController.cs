// COMP305 Assignment 1 - completed by Winnie Chung

using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    #region private instance variables
    private GameController _controller;

    private Vector2 _speed;
    private Transform _transform;
    #endregion

    #region public properties
    public AudioClip enemySound;

    public Vector2 Speed {
        get {
            return _speed;
        }

        set {
            _speed = value;
        }
    }
    #endregion

    // Use this for initialization
    void Start() {
        this._controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        this._transform = this.GetComponent<Transform>();
        this._reset();
    }

    // Update is called once per frame
    void Update() {
        this._move();
        this._borderCheck();
    }

    /// <summary>
    /// Move the game object left
    /// </summary>
    private void _move() {
        Vector2 newPos = this._transform.position;
        newPos.x -= this.Speed.x;
        newPos.y -= this.Speed.y;
        this._transform.position = newPos;

        // prevent sprite from rotating after collision
        this._transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    /// <summary>
    /// Check to see if the game object has reached the left border of the scene
    /// </summary>
    private void _borderCheck() {
        if (this._transform.position.x <= -373) {
            this._reset();
        }
    }

    /// <summary>
    /// Reset the game object back to its original position
    /// </summary>
    private void _reset() {
        Vector2 resetPos = new Vector2(373, Random.Range(-210, 208));
        this._transform.position = resetPos;
        this.Speed = new Vector2(Random.Range(5, 10), Random.Range(-3, 3));
    }

    /// <summary>
    /// Change the vertical direction of the game object
    /// </summary>
    private void _bounce() { 
        Vector2 oldSpeed = this.Speed;
        this.Speed = new Vector2(oldSpeed.x, -oldSpeed.y);
    }

    /// <summary>
    /// Event handler for game object collisions
    /// </summary>
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("doughnut")) {
            this._bounce();
        }
        else if (other.gameObject.CompareTag("Player")) {
            //Debug.Log("Enemy hit!");
            this._controller.HitEnemy();
            //GetComponent<AudioSource>().PlayOneShot(enemySound);
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(enemySound, new Vector2(0, 0));

        }
    }
}
