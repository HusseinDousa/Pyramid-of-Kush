using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float horizontal = 0f;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _jumpHeight = 20f;
    private Animator _anim;

    private Rigidbody rb;
    [SerializeField] private bool _isGrounded = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        movement();
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
        if (Input.GetButton("Jump") && _isGrounded == true)
        {
            rb.AddForce(Vector3.up * _jumpHeight);
            _anim.Play("Jump");
            _isGrounded = false;
        }
    }

    void movement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        transform.Translate(-Vector3.right * _speed * Time.deltaTime * horizontal);

    }
}
