using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed;
    public float jumping;

    public bool isJumping;

    public bool doubleJumping;
    
    private Rigidbody2D rig;
    private Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        jump();
    }

    void Move() 
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        if(Input.GetAxis("Horizontal") > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            
        }

        if(Input.GetAxis("Horizontal") < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            
        }

        if(Input.GetAxis("Horizontal") == 0f)
        {
            anim.SetBool("walk", false);
            
        }
    }

    
    void jump() 
    {
        if(Input.GetButtonDown ("Jump"))
        {   
            if(!isJumping)
            {
                rig.AddForce(new Vector2(0f, jumping), ForceMode2D.Impulse);
            doubleJumping = true;

                anim.SetBool ("jump", true);
            }
            else 
            {
                if (doubleJumping)
                {
                    rig.AddForce(new Vector2(0f, jumping * 1.2f), ForceMode2D.Impulse);
                doubleJumping = false;

                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
            anim.SetBool ("jump", false);

        }

        if(collision.gameObject.tag == "DeathTraps")
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);

        }

        

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }
    
    
}
