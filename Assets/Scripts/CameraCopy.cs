using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class CameraCopy : MonoBehaviour
{

    [SerializeField] ARTrackedImageManager arTrackedImageManager;
    [SerializeField] LayerMask cullingMask;
    // Start is called before the first frame update
    void OnEnable()
    {
        arTrackedImageManager.trackedImagesChanged += Receiver;
    }

    void OnDisable()
    {
        arTrackedImageManager.trackedImagesChanged -= Receiver;
    }

    void Receiver(ARTrackedImagesChangedEventArgs args)
    {
        GetComponent<Camera>().CopyFrom(transform.parent.GetComponent<Camera>());
        GetComponent<Camera>().cullingMask = cullingMask;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
