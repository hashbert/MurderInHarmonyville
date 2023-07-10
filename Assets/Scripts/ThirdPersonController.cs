using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonController : MonoBehaviour
{
    //input fields
    private ThirdPersonActionsAsset _playerActionsAsset;
    private InputAction _move;

    //movement fields
    [SerializeField] private float _movementForce = 1f;
    [SerializeField] private float _maxSpeed = 5f;
    private Vector3 forceDirection = Vector3.zero;

    [SerializeField] private Camera _playerCamera;
    [SerializeField] private Animator _animator;
    [SerializeField] private Collider _playerCollider;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Transform _raycastForward;
    [SerializeField] private LayerMask _NPCLayerMask;
    [HideInInspector] public NPC CurrentInteractingNPC;


    private void Awake()
    {
        _playerActionsAsset = new ThirdPersonActionsAsset();
    }

    private void OnEnable()
    {
        _playerActionsAsset.Player.Enable();
        _playerActionsAsset.Player.Interact.started += DoInteract;
        _move = _playerActionsAsset.Player.Move;
    }

    private void OnDisable()
    {
        _playerActionsAsset.Player.Interact.started -= DoInteract;
        _playerActionsAsset.Player.Disable();
    }

    private void FixedUpdate()
    {
        forceDirection += _move.ReadValue<Vector2>().x * GetCameraRight(_playerCamera) * _movementForce;
        forceDirection += _move.ReadValue<Vector2>().y * GetCameraForward(_playerCamera) * _movementForce;

        _rb.AddForce(forceDirection, ForceMode.Impulse);
        forceDirection = Vector3.zero;

        if (_rb.velocity.y < 0f)
            _rb.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;

        Vector3 horizontalVelocity = _rb.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > _maxSpeed * _maxSpeed)
            _rb.velocity = horizontalVelocity.normalized * _maxSpeed + Vector3.up * _rb.velocity.y;

        LookAt();
    }

    private void LookAt()
    {
        Vector3 direction = _rb.velocity;
        direction.y = 0f;

        if (_move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
            this._rb.rotation = Quaternion.LookRotation(direction, Vector3.up);
        else
            _rb.angularVelocity = Vector3.zero;
    }

    private Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }

    //private bool IsGrounded()
    //{
    //    Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);
    //    if (Physics.Raycast(ray, out RaycastHit hit, 0.3f))
    //        return true;
    //    else
    //        return false; 
    //}

    private void DoInteract(InputAction.CallbackContext obj)
    {
        _animator.SetTrigger("interact");
        if (CurrentInteractingNPC)
        {
            CurrentInteractingNPC.DoInteract();
        }
        //Ray ray = new Ray(_raycastForward.position, Vector3.forward);
        //RaycastHit hitData;
        //if (Physics.Raycast(ray, out hitData, 0.1f, _NPCLayerMask))
        //{
        //    NPC npc = hitData.collider.gameObject.GetComponent<NPC>();
        //    if (npc.InteractPossible)
        //    {
        //        print("interacting!");
        //    }
        //}
    }
}
