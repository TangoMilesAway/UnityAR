using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Uicontroler : MonoBehaviour
{   
    // public GameObject UIlabel;
    public GameObject gamecontrol;
    public Text carcount;
    public Image timeimg;
    public Image carpassnumimg;
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
        carcount.text = carpassnum.ToString();
        time.text = (int)gamecontrol.GetComponent<Gamecontroler>().timer + "s";
        carpassnumimg.rectTransform.localRotation = Quaternion.Euler(new Vector3(0f,0f,80f-260f*(carpassnum/100f)));
        timeimg.rectTransform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 45f - 40f * (gamecontrol.GetComponent<Gamecontroler>().timer / 10f)));

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
