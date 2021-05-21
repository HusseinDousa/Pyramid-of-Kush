using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sample : MonoBehaviour
{

    public CharacterController _controller;
    public Transform _player;
    private Vector3 _direction;
    [SerializeField] private float _speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movements();
    }

    void movements()
    {
        float horizontal = Input.GetAxis("Horizontal");
        _direction.x = horizontal * _speed;
        _controller.Move(_direction * Time.deltaTime);

        if (horizontal != 0.0f)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(horizontal, 0, 0));
            _player.rotation = newRotation;
        }

    }
}
