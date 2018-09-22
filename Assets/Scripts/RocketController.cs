using System.Collections;
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
        int alienLayer = LayerMask.NameToLayer("Alien");

        if (col.gameObject.layer == boundsLayer) {
            Destroy(gameObject);
        } else if (col.gameObject.layer == alienLayer) {
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    }


}
