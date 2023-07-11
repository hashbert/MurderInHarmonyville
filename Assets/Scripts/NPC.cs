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
    private UnityEngine.Transform _player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ThirdPersonController>() != null)
        {
            _player = other.gameObject.GetComponent<UnityEngine.Transform>();
            InteractPossible = true;
            print("interact possible" + InteractPossible);
            other.gameObject.GetComponent<ThirdPersonController>().CurrentInteractingNPC = this;
            _exclamationMark.enabled = true;
            LookAt(_player);
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
    private void LookAt(UnityEngine.Transform player)
    {
        this.transform.LookAt(player);
    }
    public void DoInteract()
    {
        print("hey buddy, how can I help" + gameObject.name);
    }
}
