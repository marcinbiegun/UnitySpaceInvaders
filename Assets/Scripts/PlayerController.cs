﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {
    public float moveSpeed = 0.1f;
    public bool fireLocked = false;

    public GameObject rocketPrefab;
    public GameObject rocketsHolder;

    void Start() {
        rocketsHolder = new GameObject(name = "RocketsHolder");
    }

    void Update() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            gameObject.transform.position += MoveVector(Direction.Left);
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            gameObject.transform.position += MoveVector(Direction.Right);
        }


        if (Input.GetKeyDown(KeyCode.Space)) {
            Fire(); 
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            LevelManager.instance.ResetRequested();
        }
    }

    Vector3 MoveVector(Direction dir) {
        float delta = Time.deltaTime * moveSpeed;
        switch (dir) {
            case Direction.Left:
                return new Vector3(-delta, 0f, 0f);
            case Direction.Right:
                return new Vector3(delta, 0f, 0f);
        }
        throw new UnityException("Unknown direction");
    }

    void Fire() {
        if (fireLocked)
            return;
        GameObject newProjectile = Instantiate(rocketPrefab, gameObject.transform);
        newProjectile.transform.SetParent(rocketsHolder.transform);
        // fireLocked = reue
    }

}
