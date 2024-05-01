using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Attack : MonoBehaviour
{

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
        if(player.GetComponent<SpriteRenderer>().flipX == false && Input.GetMouseButtonDown(0))
        {
            //Debug.Log("pesni");
            transform.localPosition = new Vector3(transform.localPosition.x * -1, transform.localPosition.y, transform.localPosition.z);
        }
        if (player.GetComponent<SpriteRenderer>().flipX == true && Input.GetMouseButtonDown(0))
        {
            transform.localPosition = new Vector3(transform.localPosition.x * -1, transform.localPosition.y, transform.localPosition.z);
        }
        //checks if the player is pressing the Left mouse button
        if (Input.GetMouseButton(0))
        {
            mysr.sprite = forcewave;
            //mysr.flipY = true;
            //mysr.flipY = false;
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
