using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace StarterAssets
{
    public class NPCInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField] private string _interactText;
        public bool InteractPossible { get; private set; }
        [SerializeField] private Image _exclamationMark;
        //[SerializeField] private Rigidbody _rb;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<ThirdPersonController>() != null)
            {
                InteractPossible = true;
                print("interact possible" + InteractPossible);
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