using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class EndingCanvas : MonoBehaviour
{
    [SerializeField] private CanvasGroup _endgameCanvasGroup;
    [SerializeField] private float _fadeInTime = 2f;
    [SerializeField] private GameObject _interactImageAndText;

    [YarnCommand("PlayEndCanvas")]
    public void PlayEndCanvas()
    {
        _endgameCanvasGroup.interactable = true;
        _endgameCanvasGroup.blocksRaycasts = true;
        LeanTween.value(_endgameCanvasGroup.gameObject, SetAlphaCallback, 0f, 1f, _fadeInTime).setEase(LeanTweenType.easeOutQuint);
        StartCoroutine(TurnOffInteractAndText());
    }

    private IEnumerator TurnOffInteractAndText()
    {
        yield return new WaitForEndOfFrame();
        _interactImageAndText.SetActive(false);
    }

    private void SetAlphaCallback(float c)
    {
        _endgameCanvasGroup.alpha = c;
    }
}
