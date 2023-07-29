using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace StarterAssets
{
    public class PlayerInteractUI : MonoBehaviour
    {

        [SerializeField] private GameObject _interactImageAndTextContainer;
        [SerializeField] private PlayerInteract playerInteract;
        [SerializeField] private TextMeshProUGUI interactTextMeshProUGUI;

        private void OnEnable()
        {
            NPCInteractable.OnInteractPossible += ToggleInteract;
            Actions.OnDialogueStart += ToggleInteractImageAndText;
            Actions.OnDialogueEnd += ToggleInteractImageAndText;
        }


        private void OnDisable()
        {
            NPCInteractable.OnInteractPossible -= ToggleInteract;
            Actions.OnDialogueStart -= ToggleInteractImageAndText;
            Actions.OnDialogueEnd -= ToggleInteractImageAndText;
        }
        private void ToggleInteractImageAndText()
        {
            if (_interactImageAndTextContainer.activeSelf)
            {
                _interactImageAndTextContainer.SetActive(false);
            }
            else
            {
                _interactImageAndTextContainer.SetActive(true);
            }
        }
        private void ToggleInteract(NPCInteractable interactable)
        {
            if (interactable.InteractPossible)
            {
                ShowInteractAndText(playerInteract.GetInteractableObject());
            }
            else
            {
                HideInteractAndText();
            }
        }

        private void ShowInteractAndText(IInteractable interactable)
        {
            _interactImageAndTextContainer.SetActive(true);
            interactTextMeshProUGUI.text = interactable.GetInteractText();
        }
        public void HideInteractAndText()
        {
            _interactImageAndTextContainer.SetActive(false);
        }

    }
}