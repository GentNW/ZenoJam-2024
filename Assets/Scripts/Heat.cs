using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Heat : MonoBehaviour
{
    //1- If player is inside the fire collision radius then decrease the slider **done**
    //2- if player is outside the fire collision radius then increase the slider **done**
    //3- if player reaches 100% of the slider then game over

    public GameObject Player;
    public UnityEngine.UI.Slider slider;

    private float slidervalue;
    private bool iswarming;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        


    }
    void FixedUpdate()
    {
        if (iswarming && slider.value != 0f)
        {
            slidervalue = slider.value - 0.001f;
            slider.value = slidervalue;
        }
        if (!iswarming && slider.value != 1f)
        {
            slidervalue = slider.value + 0.001f;
            slider.value = slidervalue;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Fire")
        {
            //Decrease the slider
            iswarming = true;
        }
        
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Fire")
        {
            //Decrease the slider
            iswarming = false;
        }
    }

}
