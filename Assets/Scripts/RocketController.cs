using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour {
    public GameObject explosionPrefab;

    void OnTriggerEnter2D(Collider2D col) {
        int boundsLayer = LayerMask.NameToLayer("Bounds");
        int alienLayer = LayerMask.NameToLayer("Alien");
        int cityLayer = LayerMask.NameToLayer("City");

        if (col.gameObject.layer == boundsLayer) {
            Destroy(gameObject);
        } else if (col.gameObject.layer == alienLayer) {
            var explosion = Instantiate(explosionPrefab, gameObject.transform);
            explosion.transform.SetParent(null);
            Destroy(gameObject);
            Destroy(col.gameObject);
            LevelManager.instance.AlienKilled();
        } else if (col.gameObject.layer == cityLayer) {
            Destroy(gameObject);
            col.gameObject.GetComponent<CityPixelController>().DetachPixelFromCity();
            LevelManager.instance.CityDamaged();
        }
    }



}
