using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MondeStart : MonoBehaviour
{

    [SerializeField] AnimationCurve fadeOutAnimationCurve;

    [SerializeField] AnimationCurve fadeInAnimationCurve;

    [SerializeField] private float fadeDuration = 5f;
    [SerializeField] private CanvasGroup fadeInCanvasGroup;

    private FadePostProcess fadePostProcess;


    public event Action faded;

    void Awake()
    {
        fadePostProcess = GameManager.Instance.FadePostProcess;
    }

    public void StartFade()
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float time = 0;

        float lastT = 0f;

        float doneWhen = fadeOutAnimationCurve.keys[fadeOutAnimationCurve.keys.Length - 1].time;

        while (time <= fadeDuration)
        {
            float then = Time.time;
            yield return new WaitForEndOfFrame();
            float delta = Time.time - then;

            float t = (time / fadeDuration);

            fadeInCanvasGroup.alpha = fadeInAnimationCurve.Evaluate(t);

            fadePostProcess.fadeValue = fadeOutAnimationCurve.Evaluate(t);

            // if (t >= doneWhen && lastT < doneWhen)
            // {
            //     faded?.Invoke();
            // }

            lastT = t;

            time += delta;
        }

        yield return new WaitForSeconds(6f);
        StartCoroutine(FadeOut());
    }


    private IEnumerator FadeOut()
    {
        float t = 0;

        float lastT = 0f;

        float doneWhen = fadeOutAnimationCurve.keys[fadeOutAnimationCurve.keys.Length - 1].time;


        while (t <= fadeDuration)
        {
            float then = Time.time;
            yield return new WaitForEndOfFrame();
            float delta = Time.time - then;

            fadePostProcess.fadeValue = 1f - fadeInAnimationCurve.Evaluate((t / fadeDuration));
            fadeInCanvasGroup.alpha = 1f - fadeOutAnimationCurve.Evaluate(t / fadeDuration);

            if (t >= doneWhen && lastT < doneWhen)
            {
                faded?.Invoke();
            }

            lastT = t;


            t += delta;
        }
    }
}
