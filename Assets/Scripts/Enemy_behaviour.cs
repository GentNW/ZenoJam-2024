using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_behaviour : MonoBehaviour
{

    //1- Walking idly **done**
    //2- Spot and pursue **done**
    //3- increase heat meters **done**

    public UnityEngine.UI.Slider slider;
    public GameObject pointA;
    public GameObject pointB;
    public GameObject dest;
    public GameObject Player;


    private float speed = 3;

    private bool canatk = false;
    private bool Walk = true;
    private bool Pursuing = false;
    private SpriteRenderer mysr;
    // Start is called before the first frame update
    void Start()
    {
        dest = pointA;
        mysr = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Pursuing && !canatk && !Walk)
        {
            Walk_to_p();
        }

        if (Walk && !canatk && !Pursuing)
        {
            Walking();
        }

        if (canatk && !Walk && !Pursuing)
        {
            Attack();
        }

    }

    void Walk_to_p()
    {
        this.transform.position = Vector2.Lerp(this.transform.position, Player.transform.position, Time.deltaTime);

        // Check if position is reached
        var dist = Vector2.Distance(this.transform.position,Player.transform.position);
        //Debug.Log(dist);
        if (dist <= 1.5)
        {
            canatk = true;
            Pursuing = false;
        }
    }
    void Attack()
    {
        slider.value = slider.value + 0.001f;
    }

    void Walking()
    {
        this.transform.position = Vector2.Lerp(this.transform.position, dest.transform.position, Time.deltaTime);

        // Check if position is reached
        var dist = Vector3.Distance(this.transform.position, dest.transform.position);

        if (dist <= 1)
        {
            // Changes position
            if (dest == pointA)
            {
                mysr.flipX = true;
                dest = pointB;
            }
            else
            {
                mysr.flipX = false;
                dest = pointA;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Pursuing = true;
            Walk = false;

        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Pursuing = false;
            //Walk = true;
        }
    }
}
