using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliensSpawner : MonoBehaviour {
    public GameObject alienPrefab;

    public float width = 1f;
    public float height = 1f;

    public float alienColumns = 10f;
    public float alienRows = 3f;

    void Start () {
        float minX = gameObject.transform.position.x - width / 2f;
        float stepX = width / (alienColumns-1);
        float minY = gameObject.transform.position.y - height / 2f;
        float stepY = height / (alienRows-1);

        for (int y = 0; y < alienRows; y++) {
            for (int x = 0; x < alienColumns; x++) {
                float offsetX = x * stepX;
                float offsetY = y * stepY;
                Vector3 position = new Vector3(minX + offsetX, minY + offsetY, 0f);
                GameObject newAlien = Instantiate(alienPrefab, position, Quaternion.identity);
            }
        }
    }

    void Update () {
	}
}
