using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AliensSpawner : MonoBehaviour {
    public GameObject alienPrefab;

    public float width = 1f;
    public float height = 1f;

    public float alienColumns = 10f;
    public float alienRows = 3f;

    public GameObject laserPrefab;
    public float shotDelaySeconds = 1f;

    public GameObject aliensHolder;
    private float lastShootAt = 0f;
    private GameObject lasersHolder;

    void Start () {
        lasersHolder = new GameObject("LasersHolder");
        aliensHolder = new GameObject(name: "AliensHolder");
        // Make a child, so aliens will move along this game object
        aliensHolder.transform.SetParent(gameObject.transform);

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
                newAlien.transform.SetParent(aliensHolder.transform);
            }
        }
    }

    void Update () {
        Shot();
	}

    void Shot() {
        if (lastShootAt > (Time.time - shotDelaySeconds))
            return;
        if (aliensHolder.transform.childCount == 0)
            return;

        var randomIndex = Random.Range(0, aliensHolder.transform.childCount);
        var randomAlien = aliensHolder.transform.GetChild(randomIndex);

        GameObject newLaser = Instantiate(laserPrefab, randomAlien.transform);
        newLaser.transform.SetParent(lasersHolder.transform);

        lastShootAt = Time.time;
    }
}
