using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMove : MonoBehaviour
{
    public float verticalSpeed = 1f;
    public float horizontalSpeed = 1f;

    public float minXPos;
    public float maxXPos;

    // Update is called once per frame
    void Update(){
        Vector3 currentPos = this.transform.localPosition;

        if ((currentPos.z > 0.7 && verticalSpeed > 0) || (currentPos.z < 0 && verticalSpeed < 0)) {
            verticalSpeed *= -1;
        }
        if ((currentPos.x > maxXPos && horizontalSpeed > 0) || (currentPos.x < minXPos && horizontalSpeed < 0)) {
            horizontalSpeed *= -1;
        }

        Vector3 newPos = this.transform.localPosition;
        newPos.x += horizontalSpeed * Time.deltaTime;
        newPos.z += verticalSpeed * Time.deltaTime;

        this.transform.localPosition = newPos;
    }
}