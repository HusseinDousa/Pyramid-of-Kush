using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _jumpHeight = 20f;
    [SerializeField] private float _gravity = -10f;
    public Transform _player;
    private Animator _anim;

    public CharacterController _controller;
    private Vector3 _direction;

    private Rigidbody rb;
    [SerializeField] private bool _isGrounded = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //movement();
        movements();
        jump();

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            _isGrounded = true;
            //Debug.Log("is grounded");
        }
    }

    void jump()
    {
        // Remove rigidbody and add y movement
        if (Input.GetButton("Jump") && _isGrounded == true)
        {
            rb.AddForce(Vector3.up * _jumpHeight);
            _anim.Play("Jump");
            _isGrounded = false;
        }
    }


    void movements()
    {
        float horizontal = Input.GetAxis("Horizontal");
        _direction.x = horizontal * _speed;
        _controller.Move(_direction * Time.deltaTime);

        _direction.y += _gravity * Time.deltaTime;

        if (horizontal != 0.0f)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(horizontal, 0, 0));
            _player.rotation = newRotation;
            _anim.SetBool("Run", true);
        }

        else if(horizontal == 0)
        {
            _anim.SetBool("Run", false);
        }


        if (transform.position.x >= 60f)
        {
            transform.position = new Vector3(60f, transform.position.y, transform.position.z);
        }

        else if (transform.position.x <= 30f)
        {
            transform.position = new Vector3(30f, transform.position.y, transform.position.z);
        }

    }
}
