using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BalloonMovement : MonoBehaviour {
    private Rigidbody2D _rb;
    public float force;
    private Vector3 _topPoint, _bottomPoint;
    private Vector2 mousePosition;
    private bool _isMoving = true;
    public bool isTop = false;
    public bool isBottom = false;
    private bool isTriggered = false;
    public float startMargin;
    public float limit;
    private AudioSource _audio;

    // Start is called before the first frame update
    void Start() {
        _audio = GetComponent<AudioSource>();
        var position = transform.position;
        _rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(position.x, position.y - startMargin, 0);
        _topPoint = new Vector3(position.x, position.y + 0.2f, 0);
        _bottomPoint = new Vector3(position.x, position.y - 0.2f, 0);
    }

    // Update is called once per frame
    void Update() {
        if (transform.position.y < 0 && _isMoving) {
            var position = transform.position;
            position = new Vector3(0, 1, 0);
            transform.Translate(position * (Time.deltaTime * 2));
        }
        else {
            if (!isTriggered) {
                _isMoving = false;
                StartUpToDown(gameObject, _rb);
                isTriggered = true;
            }

            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, limit) - 1, 0);
        }
    }


    public void StartUpToDown(GameObject gameObject, Rigidbody2D rigidbody) {
        if (!isTop) {
            if (gameObject.transform.position.y < 0.5f) {
                rigidbody.AddForce(transform.up * 0.4f);
            }
            else {
                isTop = true;
            }
        }
        else {
            if (gameObject.transform.position.y > -0.5f) {
                rigidbody.AddForce(transform.up * -0.4f);
            }
            else {
                isTop = false;
            }
        }
    }


    private void OnMouseDown() {
        foreach (Transform child in transform) {
           Destroy(child.gameObject);
           _audio.Play();
        }
    }
}