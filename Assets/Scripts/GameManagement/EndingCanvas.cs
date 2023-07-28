using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Yarn.Unity;

public class EndingCanvas : MonoBehaviour
{
    [SerializeField] private CanvasGroup _endgameCanvasGroup;
    [SerializeField] private float _fadeInTime = 2f;
    [SerializeField] private GameObject _UICanvas;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private AudioSource _mainTheme;
    [SerializeField] private AudioSource _introAndWinTheme;
    [SerializeField] private Button _playButton; 

    [YarnCommand("PlayEndCanvas")]
    public void PlayEndCanvas()
    {
        _endgameCanvasGroup.interactable = true;
        _endgameCanvasGroup.blocksRaycasts = true;
        _playButton.Select();
        LeanTween.value(_endgameCanvasGroup.gameObject, SetAlphaCallback, 0f, 1f, _fadeInTime).setEase(LeanTweenType.easeOutQuint);
        StartCoroutine(TurnOffInteractAndText());
        _mainTheme.Stop();
        _introAndWinTheme.Play();
    }

    private IEnumerator TurnOffInteractAndText()
    {
        yield return new WaitForEndOfFrame();
        _UICanvas.SetActive(false);
        _playerInput.SwitchCurrentActionMap("UI");
    }

    private void SetAlphaCallback(float c)
    {
        _endgameCanvasGroup.alpha = c;
    }
}
