using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Range(0,100)]
    public float can;
    public float speed;
    internal Animator controller;
    private bool facingRight;
    private Vector2 currentPosition;
    private Rigidbody2D rigidbody;
    private float h, v;
    // Start is called before the first frame update
    void Start()
    {
        currentPosition = transform.position;
        facingRight = false; 
        can = 100;
        speed = 5;
        rigidbody = GetComponent<Rigidbody2D>();
        controller = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            attack();
        }
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        if(h != 0)
        {
            walk();
        }
        else
        {
            unWalk();
        }
    }


    private void walk()
    {
        flip(h);
        controller.SetBool("Walk", true);
        rigidbody.velocity = new Vector2(h * speed, 0);
    }
    private void unWalk()
    {
        controller.SetBool("Walk", false);
    }

    private void flip(float h)
    {
        if (h > 0 && !facingRight || h < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector2 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    private void attack()
    {
        controller.SetFloat("Can", can/100);
        controller.SetTrigger("Attack");
    }
}
