using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit_game : MonoBehaviour
{

    public UnityEngine.UI.Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn = this.gameObject.GetComponent<UnityEngine.UI.Button>();
        btn.onClick.AddListener(quit_game);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void quit_game()
    {
        Application.Quit();
    }
}
