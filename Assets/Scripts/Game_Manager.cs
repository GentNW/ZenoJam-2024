using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    //1- Save the Checkpoint position for the player to restart at
    //2-
    // Start is called before the first frame update

    public GameObject Player;
    public Heat myheat;
    void Start()
    {
        myheat = Player.GetComponent<Heat>();
    }

    // Update is called once per frame
    void Update()
    {
        restart_position();
    }

    public void restart_position()
    {
        if (myheat.isdead)
        {
            if(myheat.cppos == null)
            {
                myheat.cppos = new Vector2(-9.26f, -0.602994f);
                myheat.isdead = false;

            }
            else 
            {
                myheat.slider.value = 0f;
                myheat.isdead = false;
                Player.transform.position = new Vector2(myheat.cppos.x, myheat.cppos.y + 2);
                //Player.GetComponent<Rigidbody2D>().MovePosition(new Vector2(myheat.cppos.x, myheat.cppos.y + 2));
            }
        }
    }
}
