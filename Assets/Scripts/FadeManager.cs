using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class FadeManager : MonoBehaviour
{
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration = 0.8f;
    public bool fadeInOnStart = true;

    void Awake()
    {
        if (fadeCanvasGroup == null) fadeCanvasGroup = GetComponent<CanvasGroup>();
        if (fadeCanvasGroup == null)
        {
            Debug.LogWarning("FadeManager: CanvasGroup not found on the same GameObject.");
            return;
        }
        fadeCanvasGroup.alpha = fadeInOnStart ? 1f : 0f;
        fadeCanvasGroup.blocksRaycasts = fadeCanvasGroup.alpha > 0.01f;
    }

    void Start()
    {
        if (fadeInOnStart) StartCoroutine(FadeTo(0f));
    }

    public void StartFadeOutAndAction(Action midAction)
    {
        StartCoroutine(FadeOutAndAction(midAction));
    }

    IEnumerator FadeOutAndAction(Action midAction)
    {
        yield return StartCoroutine(FadeTo(1f));
        midAction?.Invoke();
    }

    public IEnumerator FadeTo(float targetAlpha)
    {
        if (fadeCanvasGroup == null) yield break;
        float start = fadeCanvasGroup.alpha;
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            fadeCanvasGroup.alpha = Mathf.Lerp(start, targetAlpha, Mathf.Clamp01(elapsed / fadeDuration));
            fadeCanvasGroup.blocksRaycasts = fadeCanvasGroup.alpha > 0.01f;
            yield return null;
        }
        fadeCanvasGroup.alpha = targetAlpha;
        fadeCanvasGroup.blocksRaycasts = fadeCanvasGroup.alpha > 0.01f;
    }
}
