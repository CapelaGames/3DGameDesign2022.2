using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Collections;
using UnityEngine;

public class RBPlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 input = new Vector3();
    private bool _isGrounded = true;
    private Renderer _renderer;
    private float _groundCheckRadius = 0.5f;
    private Vector3 _groundedCheckMiddle;

    [SerializeField] private float speed = 1f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float rotationSpeed = 20f;
    [SerializeField] private Camera _camera;
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();

        if (_camera == null)
        {
            _camera = Camera.main;
            return;
        }

        if (_camera == null)
        {
            _camera = FindObjectOfType<Camera>();
        }
    }
    void Update()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _rigidbody.AddForce(Vector3.up *  Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y) 
                ,ForceMode.VelocityChange);
        }

        //transforms input to be relative to the camera
        input = Camera.main.transform.TransformDirection(input);
        input.y = 0f;
    }
    private void FixedUpdate()
    {
        _groundedCheckMiddle = _renderer.bounds.center;
        _groundedCheckMiddle.y -= _renderer.bounds.extents.y - (_renderer.bounds.extents.y * 0.20f);
        _isGrounded = Physics.CheckSphere(_groundedCheckMiddle, _groundCheckRadius * transform.localScale.y
            ,groundMask, QueryTriggerInteraction.Ignore);
        //ternary operator -------     Condition? true: false
        _rigidbody.MovePosition(_rigidbody.position + input.normalized * (speed * Time.deltaTime));
        //Quaternion.identity means no rotation
        if (input != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(input, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 
                rotationSpeed * Time.deltaTime);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(_groundedCheckMiddle, _groundCheckRadius * transform.localScale.y);
    }
}
