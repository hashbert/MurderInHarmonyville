using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
namespace StarterAssets
{
    public class PlayerInteract : MonoBehaviour
    {

        [SerializeField] private InputActionReference _interact;
        public static event Action<IInteractable> OnInteractPossibleAndClosest;

        private void OnEnable()
        {
            _interact.action.started += Interact;
        }

        private void OnDisable()
        {
            _interact.action.started -= Interact;
        }

        private void Interact(InputAction.CallbackContext obj)
        {
            if (obj.started)
            {
                IInteractable interactable = GetInteractableObject();
                if (interactable != null && interactable.IsInteractable())
                {
                    OnInteractPossibleAndClosest?.Invoke(interactable);
                    interactable.Interact(transform);
                    TurnTowards(interactable.GetTransform());
                }
            }
        }

        public IInteractable GetInteractableObject()
        {
            List<IInteractable> interactableList = new List<IInteractable>();
            float interactRange = 3f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out IInteractable interactable))
                {
                    interactableList.Add(interactable);
                }
            }

            IInteractable closestInteractable = null;
            foreach (IInteractable interactable in interactableList)
            {
                if (closestInteractable == null)
                {
                    closestInteractable = interactable;
                }
                else
                {
                    if (Vector3.Distance(transform.position, interactable.GetTransform().position) <
                        Vector3.Distance(transform.position, closestInteractable.GetTransform().position))
                    {
                        // Closer
                        closestInteractable = interactable;
                    }
                }
            }

            return closestInteractable;
        }

        private void TurnTowards(Transform direction)
        {
            Vector3 turnTo = direction.position - transform.position;
            float _targetRotationDegrees = Mathf.Atan2(turnTo.x, turnTo.z) * Mathf.Rad2Deg;
            LeanTween.rotateY(this.gameObject, _targetRotationDegrees, 0.25f);
        }

    }
}