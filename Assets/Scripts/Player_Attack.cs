using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Attack : MonoBehaviour
{

    private float push = 0.1f;
    private SpriteRenderer mysr;
    private bool right = false;

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
        if(player.GetComponent<SpriteRenderer>().flipX == true)
        {
            right = true;
        }

        if (player.GetComponent<SpriteRenderer>().flipX == false)
        {
            right = false;
        }
        //facing left
        if (player.GetComponent<SpriteRenderer>().flipX == false && Input.GetMouseButton(0))
        {
            if (transform.localPosition.x >= 1.0f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x * -1, transform.localPosition.y, transform.localPosition.z);
                right = false;
            }
            
        }

        //facing right
        if (player.GetComponent<SpriteRenderer>().flipX == true && Input.GetMouseButton(0))
        {
            if (transform.localPosition.x <= -1f && transform.localPosition.x <= 0f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x * -1, transform.localPosition.y, transform.localPosition.z);
                right = true;
            }
        }

        //checks if the player is pressing the Left mouse button
        if (Input.GetMouseButton(0))
        {
            mysr.sprite = forcewave;
        }

        else
        {
            mysr.sprite = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(Vector2.Distance(this.transform.position, col.transform.position));
        
    }

    
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Enemy" && Vector2.Distance(this.transform.position, col.transform.position) <= 1.5f && Input.GetMouseButton(0))
        {

            //Debug.Log(col.tag);
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * push, ForceMode2D.Impulse);
        }
    }
}
