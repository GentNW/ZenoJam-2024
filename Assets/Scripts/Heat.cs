using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Heat : MonoBehaviour
{
    //1- If player is inside the fire collision radius then decrease the slider **done**
    //2- if player is outside the fire collision radius then increase the slider **done**
    //3- player's color nears blue as the meter increases **done**
    //4- if player reaches 100% of the slider then game over 

    public GameObject Player;
    public UnityEngine.UI.Slider slider;
    public bool activatecp = false;
    public Vector3 cppos;

    private float slidervalue;
    private bool iswarming;
    public bool isdead;

    private Color lerpedColor = Color.white;
    SpriteRenderer Renderer;


    // Start is called before the first frame update
    void Start()
    {
        cppos = new Vector2(-12.13f, -0.59f);
        Renderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isdead)
        {
            slidervalue = 0f;
            //isdead = false;

            //SceneManager.LoadScene("Level_1");
            //SceneManager.LoadScene("Level_GameOver");
        }


    }
    void FixedUpdate()
    {
        
        if (iswarming && slider.value != 0f)
        {
            slidervalue = slider.value - 0.002f;
            slider.value = slidervalue;
            lerpedColor = Color.Lerp(Color.white, Color.cyan, slider.value);
            Renderer.material.color = lerpedColor;
        }
        if (!iswarming && slider.value != 1f)
        {
            slidervalue = slider.value + 0.001f;
            slider.value = slidervalue;
            lerpedColor = Color.Lerp(Color.white, Color.cyan, slider.value);
            Renderer.material.color = lerpedColor;
        }
        if(slider.value >= 1f)
        {
            isdead = true;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Fire")
        {
            //Decrease the slider
            iswarming = true;
            activatecp = true;
            cppos = col.gameObject.transform.position;
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
