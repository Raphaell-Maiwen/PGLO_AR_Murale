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

                GameManager.Instance.floorPlane = trackedPlane.transform;
                // GameObject go = new GameObject("floor");
                // go.transform.SetParent(trackedPlane.transform);
                // go.transform.localPosition = Vector3.zero;
                // go.transform.localRotation = Quaternion.identity;

                // go.AddComponent<ARAnchor>();
                // GameManager.Instance.floorPlane =
                // GameManager.Instance._arWorldUp = trackedPlane.normal;
                detectedFloorEvent?.Invoke();
            }
        }

        foreach (var trackedPlane in eventArgs.updated)
        {
            if (trackedPlane.alignment == PlaneAlignment.HorizontalUp)
            {
                GameManager.Instance.floorPlane = trackedPlane.transform;

                // GameManager.Instance._arWorldUp = trackedPlane.normal;
                detectedFloorEvent?.Invoke();
            }
        }

        foreach (var trackedPlane in eventArgs.removed)
        {
            if (GameManager.Instance.floorPlane == trackedPlane.transform)
            {
                GameManager.Instance.floorPlane = null;
            }
        }

    }



}
