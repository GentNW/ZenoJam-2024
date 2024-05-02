using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Attack : MonoBehaviour
{
    //1- Upon pressing left mouse button, push the enemy away from the player **done**
    //2- Change the position of the push radius depending on the sprite renderer flipx boolean **done**
    //3- display a sprite to indicate push activation **done**

    private float push = 0.1f;
    private SpriteRenderer mysr;

    public Sprite forcewave;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        mysr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //facing left
        if (player.GetComponent<SpriteRenderer>().flipX == false && Input.GetMouseButton(0))
        {
            if (transform.localPosition.x >= 1.0f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x * -1, transform.localPosition.y, transform.localPosition.z);
                push = push * -1;
            }
            
        }

        //facing right
        if (player.GetComponent<SpriteRenderer>().flipX == true && Input.GetMouseButton(0))
        {
            if (transform.localPosition.x <= -1f && transform.localPosition.x <= 0f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x * -1, transform.localPosition.y, transform.localPosition.z);
                push = push * -1;
            }
        }

        //checks if the player is pressing the Left mouse button
        if (Input.GetMouseButton(0))
        {
            mysr.sprite = forcewave;
        }
        //removes the sprite once the mouse button is no longer being pressed
        else
        {
            mysr.sprite = null;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Enemy" && Vector2.Distance(this.transform.position, col.transform.position) <= 1.5f && Input.GetMouseButton(0))
        {
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * push, ForceMode2D.Impulse);
        }
    }
}
