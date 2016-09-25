// COMP305 Assignment 1 - completed by Winnie Chung

using UnityEngine;
using System.Collections;
using System;

public class BackgroundController : MonoBehaviour {

    #region private instance variables
    private int _speed;
    private Transform _transform;
    #endregion

    #region public properties
    public int Speed {
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
        this._transform = this.GetComponent<Transform>();
        this.Speed = 5;
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
        newPos.x -= this.Speed;
        this._transform.position = newPos;
    }

    /// <summary>
    /// Check to see if the game object has reached the left border of the scene
    /// </summary>
    private void _borderCheck() {
        if (this._transform.position.x <= -320) {
            this._reset();
        }
    }

    /// <summary>
    /// Reset the game object back to its original position
    /// </summary>
    private void _reset() {
        Vector2 resetPos = new Vector2(320, 0);
        this._transform.position = resetPos;
    }
}
