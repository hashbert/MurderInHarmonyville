using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveDisplayUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _objectiveText;
    [SerializeField] private Transform _onScreenLocation;
    [SerializeField] private Transform _offScreenLocation;
    [SerializeField] private AudioClip _objectiveSound;
    [SerializeField] private AudioSource _audioSource;
    public static event Action OnVisitedEnoughNPCs;
    private void OnEnable()
    {
        DialogueManager.OnNPCVisitedForFirstTime += UpdateObjective;
    }

    private void OnDisable()
    {
        DialogueManager.OnNPCVisitedForFirstTime -= UpdateObjective;
    }

    private void UpdateObjective()
    {
        int NPCsNeededToVisitLeft = DialogueManager.GetMinNPCsVisitedCount() - DialogueManager.GetNPCsVisitedCount();
        if (NPCsNeededToVisitLeft > 0)
        {
            Shake();
            _objectiveText.text = "Visit at least " + NPCsNeededToVisitLeft 
                + " more suspects to get to the bottom of the murder.";
        }
        else
        {
            Shake();
            OnVisitedEnoughNPCs?.Invoke();
            _objectiveText.text = "Accuse unlocked! Interact with any character to make an accusation. Or interact with the statue to find out what happened!";
        }

    }
    public void SlideIn()
    {
        LeanTween.move(this.gameObject, _onScreenLocation, 0.75f);
    }
    public void SlideOut()
    {
        LeanTween.move(this.gameObject, _offScreenLocation, 0.75f);
        _audioSource.PlayOneShot(_objectiveSound);
    }
    public void Shake()
    {
        LeanTween.moveY(this.gameObject, transform.position.y - 100f, 1f).setEasePunch();
        _audioSource.PlayOneShot(_objectiveSound);
    }
}
