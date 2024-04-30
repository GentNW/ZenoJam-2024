using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    //1- when you press A untick the x flip **done**
    //2- when you press D tick the x flip **done**
    //3- Check for Ground when moving 

    private Vector2 velocityX;
    private Vector2 velocityY;
    private Vector2 velocityXY;
    private Rigidbody2D rb2D;
    private Sprite mySprite;
    private SpriteRenderer sr;

    private float lastDistance;
    private float lastDistanceV2;
    private float fforce;

    private bool isjumping;

    public Transform Ground;
    public LayerMask groundLayer;
    public float Speedx = 1.75f;
    public float Speedy = 1.75f;
    public float jumpForce = 500f;
    void Awake()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Start()
    {

        velocityX = new Vector2(Speedx, 0f);
        velocityY = new Vector2(0f, Speedy);
        velocityXY = new Vector2(Speedx, -Speedy);
    }
    void Update()
    {
        //Debug.Log(isjumping);
        //Movement
        if (Input.GetKey(KeyCode.A) == true)
        {
            sr.flipX = false;
            rb2D.MovePosition(rb2D.position + -velocityX * Time.fixedDeltaTime);
            if (isjumping)
            {
                velocityXY.Set(-Speedx, -Speedy);
                rb2D.MovePosition(rb2D.position + velocityXY * Time.fixedDeltaTime);
            }
        }
        if (Input.GetKey(KeyCode.D) == true)
        {
            sr.flipX = true;
            rb2D.MovePosition(rb2D.position + velocityX * Time.fixedDeltaTime);
            if (isjumping)
            {
                velocityXY.Set(Speedx, -Speedy);
                rb2D.MovePosition(rb2D.position + velocityXY * Time.fixedDeltaTime);
            }
        }
        //if (Input.GetKey(KeyCode.W) == true) 
        //{
        //    rb2D.MovePosition(rb2D.position + velocityY * Time.fixedDeltaTime);
        //}
        //if (Input.GetKey(KeyCode.S) == true)
        //{
        //    rb2D.MovePosition(rb2D.position + -velocityY * Time.fixedDeltaTime);
        //}


        //    Debug.DrawRay(transform.position, transform.right, Color.magenta);
        //    // Jumping
        //    float jumpAxis = Input.GetAxisRaw("Jump");

        //    if (jumpAxis != 0 && rb2D.velocity.y <= 0)
        //    {
        //        // Raycast from the feet of the player directly down (or the origin, doesn't matter)
        //        RaycastHit2D hit2D = Physics2D.Raycast(rb2D.position - new Vector2(0.5f, 0.5f), Vector2.down, 0.2f, groundLayer);

        //        // If the raycast hit something
        //        if (hit2D)
        //        {
        //            // Check if the distance of the object hit is less than the last distance checked
        //            if (hit2D.distance < lastDistance)
        //            {
        //                // Update the last distance if the object below is less than the last known distance
        //                lastDistance = hit2D.distance;
        //                isjumping = false;
        //            }
        //            else
        //            {

        //                // If the hit distance is not less than the lass distance, then jump (he isn't going to go any lower)
        //                if (!isjumping)
        //                {
        //                    lastDistance = 100f;
        //                    fforce = jumpAxis * jumpForce * Time.deltaTime;
        //                    Jump(jumpAxis * jumpForce * Time.deltaTime);
        //                }

        //            }
        //        }
        //    }



        //}
        //void Jump(float force)
        //{
        //    if (force < 0)
        //    {
        //        return;
        //    }
        //    rb2D.AddForce(new Vector2(0, force));
        //    isjumping = true;
        //}
    }
}
