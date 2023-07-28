using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class IntroCanvas : MonoBehaviour
{
    [SerializeField] private DialogueRunner _introDialogueRunner;
    [SerializeField] private CinemachineVirtualCamera _vcam;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _cameraSpinSpeed = 10f;
    [SerializeField] private float _targetRotationYInDegrees = 140f;

    // Start is called before the first frame update
    void Start()
    {
        _playerInput.SwitchCurrentActionMap("UI");
        LeanTween.rotateAround(_vcam.gameObject, Vector3.up, _targetRotationYInDegrees, _cameraSpinSpeed).setLoopPingPong();
    }

}
