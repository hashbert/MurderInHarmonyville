using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rb;
    private float maxSpeed = 5f;
    void Update()
    {
        _animator.SetFloat("speed", _rb.velocity.magnitude / maxSpeed);
    }
}
