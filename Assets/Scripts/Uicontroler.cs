using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Uicontroler : MonoBehaviour
{   
    // public GameObject UIlabel;
    public GameObject gamecontrol;
    public Text carcount;
    public int carpassnum;
    public Text time;
    public GameObject vcontrol;
    public GameObject scontrol;
    public GameObject pcontrol;
    public bool v;
    public bool s;
    public bool p;
    void Start()
    {
        // UIlabel.SetActive(true);
        v = s = p = false;
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

        vcontrol.SetActive(v);
        scontrol.SetActive(s);
        pcontrol.SetActive(p);
    }


    public void carpassnumup()
    {
        carpassnum++;
    }

    public void carpassnumclean() {
        carpassnum = 0;
    }


    public void Buttonv() {
        v = !v;
        p = false;
        s = false;
    }
    public void Buttons()
    {
        s = !s;
        v = false;
        p = false;
    }
    public void Buttonp()
    {
        p = !p;
        v = false;
        s = false;
    }

}
