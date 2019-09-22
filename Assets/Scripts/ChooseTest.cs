using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ChooseTest : MonoBehaviour {
    public bool toggle0;
    public bool toggle1;
    public bool toggle2;
    public bool toggle3;
    private bool[] ischange = new bool[]{false,false,false,false};
    public string info;

    public GameObject nextScene;

    void OnGUI()
    {
        GUI.Label("2+3=?");
        toggle0 = GUI.Toggle(toggle0,"A 3");
        toggle1 = GUI.Toggle(toggle1,"B 4");
        toggle2 = GUI.Toggle(toggle2,"C 5");
        toggle3 = GUI.Toggle(toggle3,"D 6");
        GUI.Label(info);
        if (GUI.Button("Submit"))
        {
            if(toggle2)
            {
                info = "Right!";
                nextScene.SetActive(true);

            }else 
                info = "Wrong!";
        }
        if (GUI.changed)
        {
            if (toggle0 && !ischange[0])
            {
                toggle1 = false;
                toggle2 = false;
                toggle3 = false;
                ischange = new bool[]{true,false,false,false};
            }
            if (toggle1 && !ischange[1])
            {
                toggle0 = false;
                toggle2 = false;
                toggle3 = false;
                ischange = new bool[]{false,true,false,false};

            }
            if (toggle2 && !ischange[2])
            {
                toggle0 = false;
                toggle1 = false;
                toggle3 = false;
                ischange = new bool[]{false,false,true,false};

            }
            if (toggle3 && !ischange[3])
            {
                toggle0 = false;
                toggle2 = false;
                toggle1 = false;
                ischange = new bool[]{false,false,false,true};

            }
        }
    }
    void Start()
        {
            info="";
            nextScene.SetActive(false);
        }
    void Update () 
    {

    }
}