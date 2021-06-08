using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[System.Serializable]
public class DetectedFloorEvent : UnityEvent { }

public class OnPlaneDetected : MonoBehaviour
{

    [SerializeField] ARPlaneManager m_ARPlaneManager;

    [SerializeField] DetectedFloorEvent detectedFloorEvent;

    void OnEnable()
    {
        m_ARPlaneManager.planesChanged += OnPlanesChanged;
    }

    void OnDisable()
    {
        m_ARPlaneManager.planesChanged -= OnPlanesChanged;
    }

    void OnPlanesChanged(ARPlanesChangedEventArgs eventArgs)
    {
        foreach (var trackedPlane in eventArgs.added)
        {
            if (trackedPlane.alignment == PlaneAlignment.HorizontalUp)
            {
                GameManager.Instance._arWorldUp = trackedPlane.normal;
                detectedFloorEvent?.Invoke();
                Debug.Log($"UP {trackedPlane.normal}");
            }
        }

        foreach (var trackedPlane in eventArgs.updated)
        {
            if (trackedPlane.alignment == PlaneAlignment.HorizontalUp)
            {
                GameManager.Instance._arWorldUp = trackedPlane.normal;
                detectedFloorEvent?.Invoke();
                Debug.Log($"UP {trackedPlane.normal}");
            }
        }

    }



}
