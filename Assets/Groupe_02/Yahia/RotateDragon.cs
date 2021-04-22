using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDragon : MonoBehaviour
{
    public float speed = 30f;

    void Update() {
        transform.RotateAround(transform.position, Vector3.up, speed * Time.deltaTime);
    }
}
