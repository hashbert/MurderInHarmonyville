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
        
        [SerializeField] private string _interactText;
        [SerializeField] private string _startNode;
        public bool InteractPossible { get; private set; }
        public static event Action<NPCInteractable> OnInteractPossible;
        [SerializeField] private Image _exclamationMark;
        [SerializeField] private DialogueRunner _dialogueRunner;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<ThirdPersonController>() != null)
            {
                InteractPossible = true;
                OnInteractPossible?.Invoke(this);
                print("interact possible" + InteractPossible);
                _exclamationMark.enabled = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<ThirdPersonController>() != null)
            {
                InteractPossible = false;
                OnInteractPossible?.Invoke(this);
                print("interact not possible" + InteractPossible);
                _exclamationMark.enabled = false;
            }
        }

        public void Interact(Transform interactorTransform)
        {
            print("hey buddy, how can I help" + gameObject.name);
            _dialogueRunner.StartDialogue(_startNode);
            TurnTowards(interactorTransform);
        }

        private void TurnTowards(Transform interactorTransform)
        {
            Vector3 turnTo = interactorTransform.position - transform.position;
            float _targetRotationDegrees = Mathf.Atan2(turnTo.x, turnTo.z) * Mathf.Rad2Deg;
            LeanTween.rotateY(this.gameObject, _targetRotationDegrees, 0.25f);
        }

        public string GetInteractText()
        {
            return _interactText;
        }

        public Transform GetTransform()
        {
            return transform;
        }

        public bool IsInteractable()
        {
            return InteractPossible;
        }
    }
}