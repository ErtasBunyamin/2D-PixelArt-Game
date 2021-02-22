using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Range(0,100)]
    public float can;
    public float speed;
    internal Animator controller;
    private bool isWalk;
    private Vector2 currentPosition;
    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        currentPosition = transform.position;
        isWalk = false; 
        can = 100;
        speed = 50;
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
        if (Input.GetKeyDown(KeyCode.A))
        {
            speed *= -1;
            walk(true);
        }else if (Input.GetKeyUp(KeyCode.A))
        {
            walk(false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            speed *= -1;
            walk(true);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            walk(false);
        }
    }
    private void FixedUpdate()
    {
        if(isWalk)
        {
            rigidbody.velocity = new Vector2(speed * Time.deltaTime, rigidbody.velocity.y);
        }
    }


    private void walk(bool state)
    {
        isWalk = state;
        controller.SetBool("Walk", state);
    }

    private void attack()
    {
        controller.SetFloat("Can", can/100);
        controller.SetTrigger("Attack");
    }
}
