using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitiesBoundsController : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col) {
        int alienLayer = LayerMask.NameToLayer("Alien");

        Debug.Log("Cities boudns colided with: " + col.gameObject.name);
        if (col.gameObject.layer == alienLayer) {
            LevelManager.instance.GameOver();
        }
    }
}
