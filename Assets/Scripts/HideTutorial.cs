using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class HideTutorial : MonoBehaviour
{

    [SerializeField] ARTrackedImageManager arTrackedImageManager;
    [SerializeField] ARPlaneManager arPlaneManager;

    [SerializeField] OnPlaneDetected onPlaneDetected;

    public float cameraFadeValue = 1f;

    bool hideRequested = false;

    public void Hide()
    {
        hideRequested = true;
    }

    void Update()
    {
        if (hideRequested && Time.realtimeSinceStartup >= 10f)
        {
            gameObject.SetActive(false);
            arTrackedImageManager.enabled = true;
        }

        GameManager.Instance.FadePostProcess.fadeValue = cameraFadeValue;
    }

    public void EnablePlaneDetection()
    {
        arPlaneManager.enabled = true;
        onPlaneDetected.enabled = true;
    }
}
