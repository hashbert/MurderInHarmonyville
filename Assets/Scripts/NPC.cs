using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public bool InteractPossible { get; private set; }
    [SerializeField] private Image _warningSign;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ThirdPersonController>() != null)
        {
            InteractPossible = true;
            print("interact possible" + InteractPossible);
            other.gameObject.GetComponent<ThirdPersonController>().CurrentInteractingNPC = this;
            _warningSign.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<ThirdPersonController>() != null)
        {
            InteractPossible = false;
            print("interact not possible" + InteractPossible);
            other.gameObject.GetComponent<ThirdPersonController>().CurrentInteractingNPC = null;
            _warningSign.enabled = false;
        }
    }

    public void DoInteract()
    {
        print("hey buddy, how can I help" + gameObject.name);
    }
}
