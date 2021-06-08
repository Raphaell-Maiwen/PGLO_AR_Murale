using System;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

namespace UnityEngine.XR.ARFoundation.Samples
{
    /// <summary>
    /// This component listens for images detected by the <c>XRImageTrackingSubsystem</c>
    /// and overlays some prefabs on top of the detected image.
    /// </summary>
    [RequireComponent(typeof(ARTrackedImageManager))]
    public class PrefabImagePairManager : MonoBehaviour, ISerializationCallbackReceiver
    {
        /// <summary>
        /// Used to associate an `XRReferenceImage` with a Prefab by using the `XRReferenceImage`'s guid as a unique identifier for a particular reference image.
        /// </summary>
        [Serializable]
        struct NamedPrefab
        {
            // System.Guid isn't serializable, so we store the Guid as a string. At runtime, this is converted back to a System.Guid
            public string imageGuid;
            public Bulle imageBulle;

            public NamedPrefab(Guid guid, Bulle bulle)
            {
                imageGuid = guid.ToString();
                imageBulle = bulle;
            }
        }

        [SerializeField]
        [HideInInspector]
        List<NamedPrefab> m_PrefabsList = new List<NamedPrefab>();

        Dictionary<Guid, Bulle> m_PrefabsDictionary = new Dictionary<Guid, Bulle>();
        Dictionary<Guid, GameObject> m_Instantiated = new Dictionary<Guid, GameObject>();
        ARTrackedImageManager m_TrackedImageManager;

        [SerializeField] GameObject m_BasePrefab;

        [SerializeField]
        [Tooltip("Reference Image Library")]
        XRReferenceImageLibrary m_ImageLibrary;

        /// <summary>
        /// Get the <c>XRReferenceImageLibrary</c>
        /// </summary>
        public XRReferenceImageLibrary imageLibrary
        {
            get => m_ImageLibrary;
            set => m_ImageLibrary = value;
        }

        public void OnBeforeSerialize()
        {
            m_PrefabsList.Clear();
            foreach (var kvp in m_PrefabsDictionary)
            {
                m_PrefabsList.Add(new NamedPrefab(kvp.Key, kvp.Value));
            }
        }

        public void OnAfterDeserialize()
        {
            m_PrefabsDictionary = new Dictionary<Guid, Bulle>();
            foreach (var entry in m_PrefabsList)
            {
                m_PrefabsDictionary.Add(Guid.Parse(entry.imageGuid), entry.imageBulle);
            }
        }

        void Awake()
        {
            m_TrackedImageManager = GetComponent<ARTrackedImageManager>();
        }

        void OnEnable()
        {
            m_TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
        }

        void OnDisable()
        {
            m_TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
        }

        void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
        {
            foreach (var trackedImage in eventArgs.added)
            {

                Debug.Log(trackedImage.referenceImage.name);

                // Give the initial image a reasonable default scale
                // var minLocalScalar = Mathf.Min(trackedImage.size.x, trackedImage.size.y) / 2;
                // trackedImage.transform.localScale = new Vector3(minLocalScalar, minLocalScalar, minLocalScalar);

                Debug.Log(trackedImage.referenceImage.name);

                if (m_PrefabsDictionary.TryGetValue(trackedImage.referenceImage.guid, out var prefab))
                {
                    Debug.Log(prefab.name);
                }

                AssignPrefab(trackedImage);
            }
        }

        void AssignPrefab(ARTrackedImage trackedImage)
        {
            if (m_PrefabsDictionary.TryGetValue(trackedImage.referenceImage.guid, out Bulle bulle))
            {
                // GameObject go = Instantiate(m_BasePrefab, trackedImage.transform);

                // Vector3 imageForward = Vector3.ProjectOnPlane(trackedImage.transform.up, GameManager.Instance._arWorldUp).normalized;

                // go.transform.localPosition = Vector3.zero;
                // go.transform.LookAt(go.transform.position + imageForward, GameManager.Instance._arWorldUp);
                // go.transform.localPosition = Vector3.zero;
                // go.transform.localRotation = Quaternion.identity;
         
         
                // ArSceneInstantiator arSceneInstantiator = m_BasePrefab.GetComponent<ArSceneInstantiator>();
                // Debug.Log("Bulle is ");
                // Debug.Log(bulle);
                // arSceneInstantiator.SetMonde(bulle);


                         
                BulleAnchor bulleAnchor = m_BasePrefab.GetComponentInChildren<BulleAnchor>();
                Debug.Log("Bulle is ");
                Debug.Log(bulle);
                bulleAnchor.SetMonde(bulle);

                GameObject go = Instantiate(m_BasePrefab, trackedImage.transform);
                go.transform.localPosition = Vector3.zero;
                go.transform.localRotation = Quaternion.identity;


                go.transform.GetChild(0).transform.position = trackedImage.transform.position;

                Vector3 imageForward = Vector3.ProjectOnPlane(trackedImage.transform.up, GameManager.Instance._arWorldUp).normalized;


                // Vector3 imageToCamera = GameManager.Instance.Camera.transform.forward - trackedImage.transform.position;


                // float dotProduct = Vector3.Dot(GameManager.Instance.Camera.transform.forward, imageToCamera);


                // float forwardMultiplier = 0;


                // if (dotProduct >= 0f)
                // {
                //     forwardMultiplier = -1;
                // }
                // else
                // {
                //     forwardMultiplier = 1;
                // }



                go.transform.GetChild(0).LookAt(go.transform.GetChild(0).transform.position + imageForward, GameManager.Instance._arWorldUp);
                // go.transform.SetParent(null);
                // go.transform.GetChild(0).LookAt(trackedImage.transform.position + trackedImage.transform.forward, GameManager.Instance._arWorldUp);


                Debug.Log($"image forward is {trackedImage.transform.forward}, world up is { GameManager.Instance._arWorldUp}");

                m_Instantiated[trackedImage.referenceImage.guid] = go;
            }
        }

        public Bulle GetPrefabForReferenceImage(XRReferenceImage referenceImage)
            => m_PrefabsDictionary.TryGetValue(referenceImage.guid, out Bulle bulle) ? bulle : null;

#if UNITY_EDITOR
        /// <summary>
        /// This customizes the inspector component and updates the prefab list when
        /// the reference image library is changed.
        /// </summary>
        [CustomEditor(typeof(PrefabImagePairManager))]
        class PrefabImagePairManagerInspector : Editor
        {
            List<XRReferenceImage> m_ReferenceImages = new List<XRReferenceImage>();
            bool m_IsExpanded = true;

            bool HasLibraryChanged(XRReferenceImageLibrary library)
            {
                if (library == null)
                    return m_ReferenceImages.Count == 0;

                if (m_ReferenceImages.Count != library.count)
                    return true;

                for (int i = 0; i < library.count; i++)
                {
                    if (m_ReferenceImages[i] != library[i])
                        return true;
                }

                return false;
            }

            public override void OnInspectorGUI()
            {
                //customized inspector
                var behaviour = serializedObject.targetObject as PrefabImagePairManager;

                serializedObject.Update();
                using (new EditorGUI.DisabledScope(true))
                {
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Script"));
                }


                var prefabProperty = serializedObject.FindProperty(nameof(m_BasePrefab));
                EditorGUILayout.PropertyField(prefabProperty);


                var libraryProperty = serializedObject.FindProperty(nameof(m_ImageLibrary));
                EditorGUILayout.PropertyField(libraryProperty);
                var library = libraryProperty.objectReferenceValue as XRReferenceImageLibrary;

                //check library changes
                if (HasLibraryChanged(library))
                {
                    if (library)
                    {
                        var tempDictionary = new Dictionary<Guid, Bulle>();
                        foreach (var referenceImage in library)
                        {
                            tempDictionary.Add(referenceImage.guid, behaviour.GetPrefabForReferenceImage(referenceImage));
                        }
                        behaviour.m_PrefabsDictionary = tempDictionary;
                    }
                }

                // update current
                m_ReferenceImages.Clear();
                if (library)
                {
                    foreach (var referenceImage in library)
                    {
                        m_ReferenceImages.Add(referenceImage);
                    }
                }

                //show prefab list
                m_IsExpanded = EditorGUILayout.Foldout(m_IsExpanded, "Prefab List");
                if (m_IsExpanded)
                {
                    using (new EditorGUI.IndentLevelScope())
                    {
                        EditorGUI.BeginChangeCheck();

                        var tempDictionary = new Dictionary<Guid, Bulle>();

                        if (library)
                        {
                            foreach (var image in library)
                            {

                                Bulle bulle = null;
                                if (behaviour.m_PrefabsDictionary.ContainsKey(image.guid))
                                {
                                    bulle = (Bulle)EditorGUILayout.ObjectField(image.name, behaviour.m_PrefabsDictionary[image.guid], typeof(Bulle), false);
                                }
                                tempDictionary.Add(image.guid, bulle);
                            }
                        }

                        if (EditorGUI.EndChangeCheck())
                        {
                            Undo.RecordObject(target, "Update Prefab");
                            behaviour.m_PrefabsDictionary = tempDictionary;
                            EditorUtility.SetDirty(target);
                        }
                    }
                }

                serializedObject.ApplyModifiedProperties();
            }
        }
#endif
    }
}
