using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed = 15f;
    public Animator animator;
    private bool hidden = false;
    private SpriteRenderer sprite;
    public bool dead = false;

    private Sprite idleSprite;
    public Sprite upSprite;
    public Sprite rightSprite;
    public Sprite downSprite;
    public Sprite leftSprite;

    private Rigidbody2D rb;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        idleSprite = downSprite;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(dead == false)
        {
            Move();
        }
    }

    void Move()
    {
        if(hidden == false)
        {
            float horizontalInput = 0f;
            float verticalInput = 0f;

            if (Input.GetKey(KeyCode.RightArrow))
            {
                horizontalInput = 1f;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                horizontalInput = -1f;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                verticalInput = 1f;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                verticalInput = -1f;
            }

            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow) != true)
            {
                idleSprite = rightSprite;
                animator.SetInteger("Direction", 2);
            }
            else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.UpArrow) != true)
            {
                idleSprite = downSprite;
                animator.SetInteger("Direction", 3);
            }
            else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow) != true)
            {
                idleSprite = upSprite;
                animator.SetInteger("Direction", 1);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow) != true)
            {
                idleSprite = leftSprite;
                animator.SetInteger("Direction", 4);
            }

            if(Input.GetKey(KeyCode.LeftArrow) == true || Input.GetKey(KeyCode.RightArrow) == true || Input.GetKey(KeyCode.UpArrow) == true || Input.GetKey(KeyCode.DownArrow) == true)
            {
                animator.enabled = true;
            }
            else
            {
                animator.enabled = false;
                sprite.sprite = idleSprite;
            }

            Vector3 movement = new Vector3(horizontalInput, verticalInput, 0);
            movement.Normalize();
            rb.velocity = movement * moveSpeed;
        }
    }

    public void hide()
    {
        hidden = true;
        sprite.enabled = false;
    }

    public void unhide()
    {
        hidden = false;
        sprite.enabled = true;
    }

    public void die()
    {
        animator.enabled = true;
        animator.SetBool("000",true);
        dead = true;
    }
}
