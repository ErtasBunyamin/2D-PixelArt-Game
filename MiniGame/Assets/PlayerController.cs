using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class PlayerController : MonoBehaviour
{
    [Range(1, 10)]
    public float speed;
    public Tilemap treeMap;
    private float tempSpeed;
    private float maxSpeed;
    private float h, v;
    private Vector2 closestTree;
    internal bool facingRight ,isAttacking, canCut;
    internal Animator animator;
    internal Rigidbody2D rb;
   
    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 5;
        rb.freezeRotation = true;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        //groundCheck = transform.Find("GroundCheck");
        speed = 2;
        tempSpeed = speed;
        maxSpeed = 5;
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        isAttacking = animator.GetCurrentAnimatorStateInfo(0).IsName("attack2");
        if (Input.GetMouseButtonDown(0) 
            && !isAttacking)
        {
            StartCoroutine(attack());
        }
    }


    private void FixedUpdate()
    {
        if (h != 0 && !isAttacking)
        {
            tempSpeed += Time.deltaTime;
            flip(h);
            animator.SetBool("isRun", true);
            rb.velocity = new Vector2(h * Mathf.Lerp(speed,maxSpeed, tempSpeed), 0);
        }
        else
        {
            tempSpeed = speed;
            animator.SetBool("isRun", false);
        }
            
    }
    


    IEnumerator attack()
    {
        animator.SetTrigger("isAttack");
        yield return new WaitForSeconds(1);
        if (canCut)
        {
            
        }
        
        
    }


    void flip(float h)
    {
        if (h > 0 && !facingRight || h < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector2 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
