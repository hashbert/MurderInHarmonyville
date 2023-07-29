using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Yarn.Unity;
using Cinemachine;

namespace StarterAssets
{
    public class NPCInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField] private AnimationCurve _animationCurve;
        [SerializeField] private string _interactText;
        [SerializeField] private string _startNode;
        public bool InteractPossible { get; private set; }
        public static event Action<NPCInteractable> OnInteractPossible;
        [SerializeField] private Image _exclamationMark;
        [SerializeField] private DialogueRunner _dialogueRunner;
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;
        [SerializeField] private Animator _animator;
        [SerializeField] private string _startDialogueState;
        [SerializeField] private string _endDialogueState;

        private void OnEnable()
        {
            Actions.OnDialogueEnd += SetVCamPriorityToOne;
            Actions.OnDialogueEnd += SetEndDialogueState;
        }



        private void OnDisable()
        {
            Actions.OnDialogueEnd -= SetVCamPriorityToOne;
            Actions.OnDialogueEnd -= SetEndDialogueState;
        }
        private void SetVCamPriorityToOne()
        {
            _virtualCamera.Priority = 1;
        }
        private void SetEndDialogueState()
        {
            _animator.SetTrigger(_endDialogueState);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<ThirdPersonController>() != null)
            {
                InteractPossible = true;
                OnInteractPossible?.Invoke(this);
                print("interact possible" + InteractPossible);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<ThirdPersonController>() != null)
            {
                InteractPossible = false;
                OnInteractPossible?.Invoke(this);
                print("interact not possible" + InteractPossible);
            }
        }

        public void Interact(Transform otherNPC)
        {
            print("hey buddy, how can I help" + gameObject.name);
            _dialogueRunner.StartDialogue(_startNode);
            _exclamationMark.enabled = false;
            Bounce();
            TurnTowards(otherNPC);
            _virtualCamera.Priority = 20;
            _animator.SetTrigger(_startDialogueState);
        }

        private void Bounce()
        {
            LeanTween.moveY(gameObject, transform.position.y + 0.25f, 0.25f).setEase(_animationCurve);
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