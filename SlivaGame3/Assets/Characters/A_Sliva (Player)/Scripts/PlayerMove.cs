using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private Joystick _joystick;

        private Rigidbody2D _rigidbody;
        private Animator _animator;

        [SerializeField] private float _moveSpeed;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            Move();
            Flip();
        }

        private void Move()
        {
            _rigidbody.velocity = new Vector2(_joystick.Horizontal * _moveSpeed * Time.fixedDeltaTime, _joystick.Vertical * _moveSpeed * Time.fixedDeltaTime);

            if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
            {
                _animator.SetBool("isWalking", true);
            }

            else if (_joystick.Horizontal == 0 || _joystick.Vertical == 0)
            {
                _animator.SetBool("isWalking", false);
            }
        }

        private void Flip()
        {
            if (_joystick.Horizontal > 0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            else if (_joystick.Horizontal < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}