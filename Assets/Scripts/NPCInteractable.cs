using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Yarn.Unity;

namespace StarterAssets
{
    public class NPCInteractable : MonoBehaviour, IInteractable
    {
        public event Action<NPCInteractable> OnInteractPossible;
        [SerializeField] private string _interactText;
        [SerializeField] private string _startNode;
        public bool InteractPossible { get; private set; }
        [SerializeField] private Image _exclamationMark;
        [SerializeField] private DialogueRunner _dialogueRunner;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<ThirdPersonController>() != null)
            {
                InteractPossible = true;
                print("interact possible" + InteractPossible);
                OnInteractPossible?.Invoke(this);
                _exclamationMark.enabled = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<ThirdPersonController>() != null)
            {
                InteractPossible = false;
                print("interact not possible" + InteractPossible);
                _exclamationMark.enabled = false;
            }
        }

        public void Interact(Transform interactorTransform)
        {
            print("hey buddy, how can I help" + gameObject.name);
            _dialogueRunner.StartDialogue(_startNode);
        }

        public string GetInteractText()
        {
            return _interactText;
        }

        public Transform GetTransform()
        {
            return transform;
        }
    }
}