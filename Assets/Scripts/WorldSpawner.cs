using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class WorldSpawner : MonoBehaviour
{
    [SerializeField]
    ARTrackedImageManager m_TrackedImageManager;

    [SerializeField] Texture2D[] textures;

    [SerializeField] GameObject[] prefabs;

    void OnEnable() => m_TrackedImageManager.trackedImagesChanged += OnChanged;

    void OnDisable() => m_TrackedImageManager.trackedImagesChanged -= OnChanged;

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage newImage in eventArgs.added)
        {
            Debug.Log("new Image");
            Debug.Log(newImage.referenceImage.name);
            Debug.Log(newImage.referenceImage.textureGuid);

            int i = newImage.referenceImage.name == "001" ? 0 : 1;
            GameObject go = Instantiate<GameObject>(prefabs[i]);
            go.transform.SetParent(newImage.transform);

            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = Vector3.one;
            go.transform.localRotation = Quaternion.identity;

            // newImage.referenceImage
            // Handle added event
        }

        foreach (ARTrackedImage updatedImage in eventArgs.updated)
        {
            // Handle updated event
        }
    }

}
