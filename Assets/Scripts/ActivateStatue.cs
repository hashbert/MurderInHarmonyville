using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ActivateStatue : MonoBehaviour
{
    [SerializeField] private Collider _colliderTrigger;
    [SerializeField] private Image _warningImage;

    private void OnEnable()
    {
        ObjectiveDisplayUI.OnVisitedEnoughNPCs += InteractWithStatueEnabled;
    }

    private void OnDisable()
    {
        ObjectiveDisplayUI.OnVisitedEnoughNPCs -= InteractWithStatueEnabled;
    }
    private void InteractWithStatueEnabled()
    {
        _colliderTrigger.enabled = true;
        _warningImage.enabled = true;
    }
}
