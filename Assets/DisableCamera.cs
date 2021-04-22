using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class DisableCamera : MonoBehaviour
{
    GameObject backgroundImage;
    
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("$$$ Wow super");
        
        /*
        backgroundImage = GameObject.Find("AR Session Origin/AR Camera");
        if(backgroundImage) {
            Debug.Log("---->>>>>>>>> Found AR Camera!");
        } else {
            Debug.Log("---->>>>>>>>> No AR Camera!");
        }

        backgroundImage.GetComponent<ARCameraBackground>().enabled = false;
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
