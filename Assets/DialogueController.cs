using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DialogueController : MonoBehaviour
{
    // point camera to face dialogue person
    // pause player movement
    // press esc to exit

    public GameObject character;
    public GameObject player;
    public CinemachineFreeLook freeLookCam;
    public bool dialogueMode;

    private void Start()
    {


    }

    private void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            if(dialogueMode == false)
            {
                focusCamera(character);
                dialogueMode = true;
            }
            else
            {
                focusCamera(player);
                dialogueMode = false;
            }

        }
    }

    private void focusCamera(GameObject target)
    {
        // Assuming the character has been assigned in the inspector
        freeLookCam.Follow = target.transform;
        freeLookCam.LookAt = target.transform;
    }



}
