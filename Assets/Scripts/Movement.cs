using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    //1- when you press A untick the x flip **done**
    //2- when you press D tick the x flip **done**
    //3- Move while in the air **done**

    public Transform Ground;
    public LayerMask groundLayer;
    public float Speedx = 1.75f;

    private Rigidbody2D rb2D;
    private Sprite mySprite;
    private SpriteRenderer sr;
    private Animator anim;

    private float lastDistance;
    private float lastDistanceV2;
    private float fforce;

    private bool isJumping;

   

    private float jumpForce = 5f;
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        
    }
    void FixedUpdate()
    {

        // we store the initial velocity, which is a struct.
        var v = rb2D.velocity;

        if (v.y == 0f)
            isJumping = false;

        if (Input.GetKey(KeyCode.Space) && !isJumping)
        {
            v.y = jumpForce;
            isJumping = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            sr.flipX = false;
            v.x = -Speedx;
        }


        if (Input.GetKey(KeyCode.D))
        {
            sr.flipX = true;
            v.x = Speedx;
        }

        rb2D.velocity = v;

        if (Input.GetKey(KeyCode.A) == true || Input.GetKey(KeyCode.D) == true)
        {
            anim.SetBool("Iswalking", true);
        }
        else
        {
            anim.SetBool("Iswalking", false);
        }
    }
}
