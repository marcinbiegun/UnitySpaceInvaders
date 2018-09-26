using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour {
    public float animationTime = 1000f;
    public Vector3 scaleAddition = new Vector3(0f, 0f, 0f) ;
    private float createdAt;

    void Start () {
        createdAt = Time.time;
	}
	
	void Update () {
        if (Time.time < createdAt + animationTime) {
            gameObject.transform.localScale += Time.deltaTime * (scaleAddition/animationTime);
        } else {
            Destroy(gameObject);
        }
	}
}
