using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace StarterAssets
{
    public class PlayerInteractUI : MonoBehaviour
    {

        [SerializeField] private GameObject containerGameObject;
        [SerializeField] private PlayerInteract playerInteract;
        [SerializeField] private TextMeshProUGUI interactTextMeshProUGUI;

        private void OnEnable()
        {
            NPCInteractable.OnInteractPossible += ToggleInteract;
        }
        private void OnDisable()
        {
            NPCInteractable.OnInteractPossible -= ToggleInteract;
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
            containerGameObject.SetActive(true);
            interactTextMeshProUGUI.text = interactable.GetInteractText();
        }
        public void HideInteractAndText()
        {
            containerGameObject.SetActive(false);
        }

    }
}