using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
    {   
        [SerializeField]private float _playerSpeed = 5;
        [SerializeField]private float _jumpForce = 5;
        private float _playerInputHorizontal;
        private float _playerInputVertical;
        private Rigidbody2D _rBody2D;
        private Animator _animator;
        private SpriteRenderer _renderer;

        // Start is called before the first frame update

        void Start()
        {
            _rBody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponentInChildren<Animator>();

            Debug.Log(GameManager.instance.vidas);
        }

        // Update is called once per frame
        void Update()
        {
            PlayerMovement(); 

            if(Input.GetButtonDown("Jump") && GroundSensor._isGrounded)
            {
                Jump();
            }
        }

        void Jump()
        {
            _rBody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _animator.SetBool("IsJumping", true);
        }

        void FixedUpdate() 
        {
            _rBody2D.velocity = new Vector2(_playerInputHorizontal * _playerSpeed, _rBody2D.velocity.y);
        }

        void PlayerMovement()
        {
            _playerInputHorizontal = Input.GetAxis ("Horizontal");

            if(_playerInputHorizontal < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                _animator.SetBool("IsRunning", true);
            }
            else if(_playerInputHorizontal > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                _animator.SetBool("IsRunning", true);
            }

            else
            {
                _animator.SetBool("IsRunning", true);
            }

        }
    }