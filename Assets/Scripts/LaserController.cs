using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour {
    public GameObject explosionPrefab;

    void OnTriggerEnter2D(Collider2D col) {
        int boundsLayer = LayerMask.NameToLayer("Bounds");
        int alienLayer = LayerMask.NameToLayer("Alien");
        int cityLayer = LayerMask.NameToLayer("City");
        int playerLayer = LayerMask.NameToLayer("Player");

        if (col.gameObject.layer == boundsLayer) {
            Destroy(gameObject);
        } else if (col.gameObject.layer == cityLayer) {
            LevelManager.instance.CityDamaged();
            col.gameObject.GetComponent<CityPixelController>().DetachPixelFromCity();
            col.gameObject.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        } else if (col.gameObject.layer == playerLayer) {
            LevelManager.instance.PlayerDied();
            var explosion = Instantiate(explosionPrefab, gameObject.transform);
            explosion.transform.SetParent(null);
            Destroy(gameObject);
        }
    }
}
