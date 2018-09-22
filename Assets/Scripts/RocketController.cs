﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col) {
        int boundsLayer = LayerMask.NameToLayer("Bounds");

        Debug.Log(col.gameObject.name);
        if (col.gameObject.layer == boundsLayer) {
            Destroy(gameObject);
        }
    }


}
