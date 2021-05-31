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
    [SerializeField] private bool _isGrounded = true;

    private void Awake()
    {
        //rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        movements();
        jump();
        collisionDetection();


    }

    void collisionDetection()
    {
        if (_controller.collisionFlags == CollisionFlags.Below)
        {
            _isGrounded = true;
            Debug.Log("is grounded");
        }

        else if (_controller.collisionFlags == CollisionFlags.None)
        {
            Debug.Log("Jumping");
        }

    }

    void jump()
    {
        if (Input.GetButton("Jump") && _isGrounded == true)
        {
            _direction.y = _jumpHeight * Time.deltaTime;
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

        if (transform.position.z != 20f)
        {
            Vector3 _position = new Vector3(transform.position.x, transform.position.y, 20f);
            transform.position = _position;
        }

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Treasure")
        {
            // destroys treasure
            Destroy(hit.gameObject);
            Debug.Log("Took collectible");
        }
    }
}
