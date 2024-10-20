using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer spriteRenderer;

    public float x;
    public int speed = 2;
    public int jumpingPower = 5;
    public bool walk = false;
    public bool run = false;

    public bool isJump;
    public bool isHit;
    void Start()
    {
        Transform transform = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    public void PlayGame()
    {
        if (isHit)
        {
            SceneManager.LoadSceneAsync(0);
        }
    }

    void Update()
    {
        if (isHit)
        {
            SceneManager.LoadSceneAsync(0);
        }
        x = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(x * speed, rb.velocity.y);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            run = true;
        }
        else
        {
            run= false;
        }

        if (Input.GetButtonDown("Jump") && isJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            anim.SetBool("Jump", true);
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
        }

        if (x != 0 && run && isJump)
        {
            anim.SetBool("Run", true);
            anim.SetBool("Walk", false);
            speed = 4;
        }
        else if (x != 0 && !run && isJump)
        {
            anim.SetBool("Run", false);
            anim.SetBool("Walk", true);
            speed = 2;
        }
        else
        {
            anim.SetBool("Jump", false);
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJump = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            isHit = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJump = false;
            anim.SetBool("Jump", true);
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            isHit = false;
        }
    }
}
