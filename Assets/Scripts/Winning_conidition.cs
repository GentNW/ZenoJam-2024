using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winning_conidition : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Ship" && this.gameObject.GetComponent<BoxCollider2D>().IsTouching(col))
        {
            Debug.Log("You Won!");
        }
    }
}
