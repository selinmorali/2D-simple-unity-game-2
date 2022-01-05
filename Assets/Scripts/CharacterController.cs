using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float jumpForce = 10f;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    bool grounded;
    bool started;
    bool jumping;
 
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>(); //cashing
        _animator = GetComponent<Animator>();
        grounded = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(name: "space")) 
        {
            if (started && grounded)
            {
                _animator.SetTrigger("jump");
                grounded = false;
                jumping = true;
            }
            else
            {
                _animator.SetBool("gamestarted", true);
                started = true;
            }
        }

         _animator.SetBool("grounded", grounded);
    }

    private void FixedUpdate()
    {
        if (started)
        {
            _rigidbody2D.velocity = new Vector2(speed, _rigidbody2D.velocity.y);
        }

        if (jumping)
        {
            _rigidbody2D.AddForce(new Vector2(0.0f, jumpForce));
            jumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground")){
            grounded = true;
        }
    }






}
