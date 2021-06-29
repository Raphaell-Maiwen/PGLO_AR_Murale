using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity​Engine.XR.ARFoundation;


public class AlignUp : MonoBehaviour
{

    void Awake()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.floorPlane)
        {
            //if (Application.platform == RuntimePlatform.Android)
            //{
                transform.LookAt(transform.position + transform.forward, GameManager.Instance.floorPlane.up);
            //}
        }
        // if (trackedTransform)
        // {
        //     // transform.LookAt(transform.position + trackedTransform.forward, GameManager.Instance._arWorldUp);
        // }
    }
}
