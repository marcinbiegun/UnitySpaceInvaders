using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityPixelController : MonoBehaviour {

    public void DetachPixelFromCity() {
        // Disable collisions
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        var rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        // Enable grafity freefall
        rigidbody2d.gravityScale = 1f;

        // Add random force
        rigidbody2d.AddForce(Random.insideUnitCircle * 100f);
    }
}
