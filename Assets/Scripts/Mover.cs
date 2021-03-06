﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public Vector3 move = new Vector3(0f, 0f, 0f);
    public Vector3 scale = new Vector3(0f, 0f, 0f);

    void Update () {
        gameObject.transform.position += move * Time.deltaTime;
        gameObject.transform.localScale += scale * Time.deltaTime;
    }
}
