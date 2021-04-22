using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;


public class AR_BackgroundEffect : MonoBehaviour
{

    ARTrackedImageManager _tracker;
    bool refreshPosition = true;

    // Start is called before the first frame update
    void Start()
    {
        _tracker = gameObject.GetComponent<ARTrackedImageManager>();
        if(_tracker == null) {
            Debug.Log("SHIT TRACKER IMAGE MANAGER");
        }
    }


    // Update is called once per frame
    void LateUpdate()
    {
        if (refreshPosition == false) {
            _tracker.subsystem.Stop();
        }
        
        if (_tracker.trackables.count > 0) {
            refreshPosition = false;
        }
    }

}
