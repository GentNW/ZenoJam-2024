using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItchPageBtn : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEngine.UI.Button btn;
    void Start()
    {
        btn = this.gameObject.GetComponent<UnityEngine.UI.Button>();
        btn.onClick.AddListener(gotolink);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void gotolink()
    {
          Application.OpenURL("https://gentleman-nwah.itch.io/");
    }
}
