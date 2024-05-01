using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Restart_level : MonoBehaviour
{
    //1- Add a listener to execute the restart level function **done**

    public UnityEngine.UI.Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn = this.gameObject.GetComponent<UnityEngine.UI.Button>();
        btn.onClick.AddListener(restart);
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void restart()
    {
        SceneManager.LoadScene("Level_1");
    }
}
