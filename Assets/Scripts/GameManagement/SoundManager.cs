using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour {


    private const string PLAYER_PREFS_SOUND_EFFECTS_VOLUME = "SoundEffectsVolume";
    public static SoundManager Instance { get; private set; }

    private float volume = 1f;

    [SerializeField] private AudioSource _continueClick;
    [SerializeField] private AudioSource _optionSelected;

    private void Awake() {
        Instance = this;

        volume = PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_EFFECTS_VOLUME, 1f);
    }

    private void OnEnable()
    {
        Actions.OnContinueClicked += PlayContinueClicked;
        Actions.OnOptionSelected += PlayOptionSelected;
    }


    private void OnDisable()
    {
        Actions.OnContinueClicked -= PlayContinueClicked;
        Actions.OnOptionSelected -= PlayOptionSelected;
    }
    private void PlayOptionSelected()
    {
        PlaySound(_optionSelected);
    }
    private void PlayContinueClicked()
    {
        PlaySound(_continueClick);
        print("hello i've clicked continue...");
    }
    public void PlaySound(AudioSource audioSource) {
        audioSource.PlayOneShot(audioSource.clip);
    }
    public void ChangeVolume() {
        volume += .1f;
        if (volume > 1f) {
            volume = 0f;
        }

        PlayerPrefs.SetFloat(PLAYER_PREFS_SOUND_EFFECTS_VOLUME, volume);
        PlayerPrefs.Save();
    }

    public float GetVolume() {
        return volume;
    }


}