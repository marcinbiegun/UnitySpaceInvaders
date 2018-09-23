using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col) {
        int boundsLayer = LayerMask.NameToLayer("Bounds");
        int alienLayer = LayerMask.NameToLayer("Alien");
        int cityLayer = LayerMask.NameToLayer("City");
        int playerLayer = LayerMask.NameToLayer("Player");

        if (col.gameObject.layer == boundsLayer) {
            Destroy(gameObject);
        } else if (col.gameObject.layer == cityLayer) {
            Destroy(gameObject);
            col.gameObject.GetComponent<CityPixelController>().DetachPixelFromCity();
            LevelManager.instance.CityDamaged();
        } else if (col.gameObject.layer == playerLayer) {
            Destroy(gameObject);
            LevelManager.instance.PlayerDied();
        }
    }
}
