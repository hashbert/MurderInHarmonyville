using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public bool InteractPossible { get; private set; }
    [SerializeField] private Image _exclamationMark;
    [SerializeField] private Rigidbody _rb;
    private Transform _player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ThirdPersonController>() != null)
        {
            _player = other.gameObject.GetComponent<Transform>();
            InteractPossible = true;
            print("interact possible" + InteractPossible);
            other.gameObject.GetComponent<ThirdPersonController>().CurrentInteractingNPC = this;
            _exclamationMark.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<ThirdPersonController>() != null)
        {
            InteractPossible = false;
            print("interact not possible" + InteractPossible);
            other.gameObject.GetComponent<ThirdPersonController>().CurrentInteractingNPC = null;
            _exclamationMark.enabled = false;
            _player = null;
        }
    }
    private void LookAt(Transform player)
    {
        Vector3 direction = player.;
        direction.y = 0f;

        if (_move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
            this._rb.rotation = Quaternion.LookRotation(direction, Vector3.up);
        else
            _rb.angularVelocity = Vector3.zero;
    }
    public void DoInteract()
    {
        print("hey buddy, how can I help" + gameObject.name);
    }
}
