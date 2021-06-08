using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity​Engine.XR.ARFoundation;


public class AlignUp : MonoBehaviour
{

    Transform trackedTransform;

    void Awake()
    {
        trackedTransform = GetComponentInParent<ARTrackedImage>()?.transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (trackedTransform)
        {
            transform.LookAt(transform.position + trackedTransform.forward, GameManager.Instance._arWorldUp);
        }
    }
}
