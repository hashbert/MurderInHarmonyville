using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    [SerializeField] private AudioSource _mainTheme;
    [SerializeField] private AudioSource _introAndWinTheme;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        IntroCanvas.OnPlayClicked += PlayMainMusic;
        EndingCanvas.OnPlayEndCanvas += PlayIntroEndMusic;
        
    }


    private void OnDisable()
    {
        IntroCanvas.OnPlayClicked -= PlayMainMusic;
        EndingCanvas.OnPlayEndCanvas -= PlayIntroEndMusic;
    }
    private void PlayMainMusic()
    {
        _introAndWinTheme.Stop();
        _mainTheme.Play();
    }
    private void PlayIntroEndMusic()
    {
        _mainTheme.Stop();
        _introAndWinTheme.Play();
    }
}
