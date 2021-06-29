using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MondeStart : MonoBehaviour
{

    [SerializeField] AnimationCurve fadeOutAnimationCurve;

    [SerializeField] AnimationCurve fadeInAnimationCurve;

    [SerializeField] private float fadeInDuration = 5f;
    [SerializeField] private float fadeOutDuration = 5f;

    // [SerializeField] private CanvasGroup fadeInCanvasGroup;

    [SerializeField] private SpriteRenderer[] presentationSpriteRenderers;

    private FadePostProcess fadePostProcess;


    public event Action faded;

    void Awake()
    {
        fadePostProcess = GameManager.Instance.FadePostProcess;

        for (int i = 0; i < presentationSpriteRenderers.Length; i++)
        {
            Color color = presentationSpriteRenderers[i].color;
            presentationSpriteRenderers[i].color = new Color(color.r, color.g, color.b, 0f);
        }
    }

    public void StartFade()
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        Debug.Log("Commence fade in ");
        Debug.Log(Time.time);

        float time = 0;

        float lastT = 0f;

        float doneWhen = fadeInAnimationCurve.keys[fadeOutAnimationCurve.keys.Length - 1].time;

        while (time <= fadeInDuration)
        {
            float then = Time.time;
            yield return new WaitForEndOfFrame();
            float delta = Time.time - then;

            float t = (time / fadeInDuration);

            // fadeInCanvasGroup.alpha = fadeInAnimationCurve.Evaluate(t);

            float value = fadeInAnimationCurve.Evaluate(t);

            for (int i = 0; i < presentationSpriteRenderers.Length; i++)
            {
                Color color = presentationSpriteRenderers[i].color;
                presentationSpriteRenderers[i].color = new Color(color.r, color.g, color.b, value);
            }

            fadePostProcess.fadeValue = value;

            // if (t >= doneWhen && lastT < doneWhen)
            // {
            //     faded?.Invoke();
            // }

            lastT = t;

            time += delta;
        }

        for (int i = 0; i < presentationSpriteRenderers.Length; i++)
        {
            Color color = presentationSpriteRenderers[i].color;
            presentationSpriteRenderers[i].color = new Color(color.r, color.g, color.b, 1f);
        }
        fadePostProcess.fadeValue = 1f;

        yield return new WaitForSeconds(3f);
        StartCoroutine(FadeOut());

        Debug.Log("Fini fade in ");
        Debug.Log(Time.time);
    }


    private IEnumerator FadeOut()
    {
        Debug.Log("Commence fade out ");
        Debug.Log(Time.time);

        float time = 0;

        float lastT = 0f;

        float doneWhen = fadeInAnimationCurve.keys[fadeOutAnimationCurve.keys.Length - 1].time;

        while (time <= fadeOutDuration)
        {
            float then = Time.time;
            yield return new WaitForEndOfFrame();
            float delta = Time.time - then;

            float t = (time / fadeOutDuration);

            // fadeInCanvasGroup.alpha = fadeInAnimationCurve.Evaluate(t);

            float value = 1f - fadeInAnimationCurve.Evaluate(t);

            for (int i = 0; i < presentationSpriteRenderers.Length; i++)
            {
                Color color = presentationSpriteRenderers[i].color;
                presentationSpriteRenderers[i].color = new Color(color.r, color.g, color.b, value);
            }

            fadePostProcess.fadeValue = value;

            // if (t >= doneWhen && lastT < doneWhen)
            // {
            //     faded?.Invoke();
            // }

            lastT = t;

            time += delta;
        }

        for (int i = 0; i < presentationSpriteRenderers.Length; i++)
        {
            Color color = presentationSpriteRenderers[i].color;
            presentationSpriteRenderers[i].color = new Color(color.r, color.g, color.b, 0f);
        }
        fadePostProcess.fadeValue = 0f;

        faded?.Invoke();


        Debug.Log("Fini fade out ");
        Debug.Log(Time.time);
    }

    // private IEnumerator FadeOut()
    // {
    //     Debug.Log("Commence fade out ");
    //     Debug.Log(Time.time);
    //     float t = 0;

    //     float lastT = 0f;

    //     float doneWhen = fadeOutAnimationCurve.keys[fadeOutAnimationCurve.keys.Length - 1].time;


    //     while (t <= fadeDuration)
    //     {
    //         float then = Time.time;
    //         yield return new WaitForEndOfFrame();
    //         float delta = Time.time - then;

    //         float value = 1f - fadeInAnimationCurve.Evaluate((t / fadeDuration));

    //         fadePostProcess.fadeValue = value;
    //         // fadeInCanvasGroup.alpha = 1f - fadeOutAnimationCurve.Evaluate(t / fadeDuration);

    //         for (int i = 0; i < presentationSpriteRenderers.Length; i++)
    //         {
    //             Color color = presentationSpriteRenderers[i].color;
    //             presentationSpriteRenderers[i].color = new Color(color.r, color.g, color.b, value);
    //         }

    //         if (t >= doneWhen && lastT < doneWhen)
    //         {
    //             faded?.Invoke();
    //         }

    //         for (int i = 0; i < presentationSpriteRenderers.Length; i++)
    //         {
    //             Color color = presentationSpriteRenderers[i].color;
    //             presentationSpriteRenderers[i].color = new Color(color.r, color.g, color.b, 0f);
    //         }
    //         fadePostProcess.fadeValue = 0f;

    //         lastT = t;


    //         t += delta;


    //     }


    //     Debug.Log("Fini fade out ");
    //     Debug.Log(Time.time);
    // }
}
