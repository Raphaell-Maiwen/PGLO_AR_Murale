using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] public Vector3 _arWorldUp;


    [SerializeField] private Camera _camera;

    private bool _isLocked = false;

    private ArSceneInstantiator currentBulle = null;

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
}
