using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] public Vector3 _arWorldUp;

    public Transform floorPlane;

    [SerializeField] private float fadeDuration;


    [SerializeField] private Camera _camera;

    [SerializeField] private AnimationCurve animationCurve;

    private bool _isLocked = false;

    private ArSceneInstantiator currentBulle = null;

    UnityEngine.XR.ARFoundation.ARCameraBackground _arCameraBackground = null;

    public bool IsLocked
    {
        get
        {
            return _isLocked;
        }
    }

    public ArSceneInstantiator CurrentBulle
    {
        get
        {
            return currentBulle;
        }
    }

    [SerializeField] UnityEngine.XR.ARFoundation.ARSessionOrigin _arSessionOrigin;

    public Transform ARSessionOrigin
    {
        get
        {
            return _arSessionOrigin.trackablesParent;
        }
    }


    protected override void Awake()
    {
        base.Awake();

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    public Camera Camera
    {
        get
        {
            return _camera;
        }
    }

    public UnityEngine.XR.ARFoundation.ARCameraBackground ARCameraBackground
    {
        get
        {
            if (_arCameraBackground == null)
            {
                _arCameraBackground = _camera.GetComponent<UnityEngine.XR.ARFoundation.ARCameraBackground>();
            }

            return _arCameraBackground;
        }
    }

    [SerializeField] private CanvasGroup _fadeCanvasGroup;

    public CanvasGroup FadeCanvasGroup
    {
        get
        {
            return _fadeCanvasGroup;
        }
    }

    [SerializeField] private FadePostProcess _fadePostProcess;

    public FadePostProcess FadePostProcess
    {
        get
        {
            return _fadePostProcess;
        }
    }

    public void Lock(ArSceneInstantiator bulle)
    {
        if (!IsLocked)
        {
            currentBulle = bulle;
            _isLocked = true;
        }
    }

    public void Unlock(ArSceneInstantiator bulle)
    {
        if (bulle == currentBulle)
        {
            _isLocked = false;
        }
    }

    public void FadeIn()
    {
        StartCoroutine(IEFadeIn());
    }

    public void FadeOut()
    {
        Debug.Log("FadeOut");
        StartCoroutine(IEFadeOut());
    }

    IEnumerator IEFadeOut()
    {

        float time = 0;


        while (time <= fadeDuration)
        {
            float then = Time.time;
            yield return new WaitForEndOfFrame();
            float delta = Time.time - then;

            float t = (time / fadeDuration);

            _fadePostProcess.fadeValue = t;

            // _arMaterial.SetFloat("_dimFactor", 1f - t);

            time += delta;
        }
    }

    IEnumerator IEFadeIn()
    {

        float time = 0;


        while (time <= fadeDuration)
        {
            float then = Time.time;
            yield return new WaitForEndOfFrame();
            float delta = Time.time - then;

            float t = (time / fadeDuration);

            _fadePostProcess.fadeValue = 1f - t;

            // _arMaterial.SetFloat("_dimFactor", 1f - t);

            time += delta;
        }
    }
}
