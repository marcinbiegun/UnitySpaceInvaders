using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMover : MonoBehaviour {
    public float width = 1f;
    public float horizontalSpeed = 1f;
    public float verticalStep = 1f;

    private HorizontalDirection direction = HorizontalDirection.Left;
    private Vector3 originalPosition = new Vector3(0f, 0f, 0f);

    // Use this for initialization
    void Start () {
        originalPosition = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        // Switch direction if touching the limit, and step vertically
        float x = gameObject.transform.position.x;
        float minX = originalPosition.x - width / 2f;
        float maxX = originalPosition.x + width / 2f;

        if (x < minX) {
            direction = HorizontalDirection.Right;
            VerticalStep();
        } else if (x > maxX) {
            direction = HorizontalDirection.Left;
            VerticalStep();
        }

        // Always perform horizontal move
        HorizontalMove();
    }

    void HorizontalMove() {
        float xDirection = direction == HorizontalDirection.Left ? -1f : 1f;
        Vector3 move = new Vector3(xDirection * horizontalSpeed, 0f, 0f);
        gameObject.transform.position += move * Time.deltaTime;

    }

    void VerticalStep() {
        Vector3 move = new Vector3(0f, verticalStep, 0f);
        gameObject.transform.position += move;
    }
}
