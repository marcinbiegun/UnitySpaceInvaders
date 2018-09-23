using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityPixelController : MonoBehaviour {

    public float detachForce = 100f;
    public float detachTorque = 100f;

    public void DetachPixelFromCity() {
        // Disable collisions
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        var rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        // Enable grafity freefall
        rigidbody2d.gravityScale = 1f;

        // Add random force
        rigidbody2d.AddForce(Random.insideUnitCircle * detachForce * Random.Range(.5f, 1.5f));
        rigidbody2d.AddTorque(detachTorque * Random.Range(-1.5f, 1.5f));
    }


    void OnTriggerEnter2D(Collider2D col) {
        int boundsLayer = LayerMask.NameToLayer("Bounds");

        if (col.gameObject.layer == boundsLayer) {
            Destroy(gameObject);
        }
    }
}
