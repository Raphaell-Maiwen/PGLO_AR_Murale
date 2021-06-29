using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundAxis : MonoBehaviour
{
    public float x_rotation = 0.0f;
    public float y_rotation = 0.0f;
    public float z_rotation = 0.0f;
    
    Vector3 r;

    // Start is called before the first frame update
    void Start()
    {
        r = new Vector3(x_rotation, y_rotation, z_rotation);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(r, Space.Self);
    }
}
