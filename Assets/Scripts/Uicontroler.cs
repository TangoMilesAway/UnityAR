using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Uicontroler : MonoBehaviour
{
    public GameObject gamecontrol;
    public Text carcount;
    public int carpassnum;
    public Text time;
    void Start()
    {
        carpassnum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gamecontrol.GetComponent<Gamecontroler>().timer <=0.05f)
        {
            carpassnum = 0;
        }
        carcount.text = "车辆通过数为：" + carpassnum;
        time.text = "时间:" + (int)gamecontrol.GetComponent<Gamecontroler>().timer + "s";
    }


    public void carpassnumup()
    {
        carpassnum++;
    }

    public void carpassnumclean() {
        carpassnum = 0;
    }
}
