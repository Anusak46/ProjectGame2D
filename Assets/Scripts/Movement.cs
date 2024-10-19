using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer spriteRenderer;

    public float x;
    public int speed = 2;
    //public int jumpingPower = 2;
    public bool walk = false;
    public bool run = false;
    void Start()
    {
        Transform transform = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(x * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            run = true;
        }
        else
        {
            run= false;
        }

        if (x != 0 && run)
        {
            anim.SetBool("Run", true);
        }
        else if (x!=0)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
        }

        if (Input.GetButtonDown("Jump"))
        {
            //rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}
