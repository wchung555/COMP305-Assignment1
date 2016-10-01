// COMP305 Assignment 1 - completed by Winnie Chung

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class CatController : MonoBehaviour {

    #region private instance variables
    private Transform _transform;
    private int _speed = 10;
    #endregion

    // Use this for initialization
    void Start () {
        this._transform = this.GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        this._move();
    }

    /// <summary>
    /// Move the game controller vertically according to the mouse's movement
    /// </summary>
    private void _move() {
        float moveY = Input.GetAxis("Vertical")*this._speed;
        this._transform.Translate(new Vector2(0, moveY));
        this._transform.position = new Vector2(-270, Mathf.Clamp(this._transform.position.y, -220, 220));

        // prevent sprite from rotating after collision
        this._transform.rotation = new Quaternion(0, 0, 0, 0);
    }
}
