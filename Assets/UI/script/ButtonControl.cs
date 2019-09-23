using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    public GameObject startPanel;//初始页面

    public GameObject SetPanel;//设置页面
 

    // Start is called before the first frame update
    void Start()
    {
        startPanel.SetActive(true );
        SetPanel.SetActive(false );
    }

   
    public  void optionClick()
    {

        startPanel.SetActive(false);
        SetPanel.SetActive(true);
    }

    public void backClick()
    {

        startPanel.SetActive(true );
        SetPanel.SetActive(false);
    }
}
