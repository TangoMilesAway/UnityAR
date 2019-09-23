using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamecontroler : MonoBehaviour
{
    public GameObject[] roadtypes;
    public GameObject startpoint;
    public int oldroadnum;
    public int newroadnum;
    public bool startcontrol;
    public float timer;
    public float runtime;
    public float carspeed;
    public GameObject roadgathers;
    public float speedplus;
    public int roadmod;
    public int roadmaterialtype;
    // Start is called before the first frame update
    void Start()
    {
        startcontrol = false;
        for (int i = 1; i <= oldroadnum; i++)
        {
            if (i == 1) {
                roadmod = 0;
            }
            if (i == oldroadnum)
            {
                roadmod = 2;
            }
            GameObject newroad = Instantiate(roadtypes[roadmod]);
            newroad.transform.position = startpoint.transform.position + new Vector3(roadtypes[roadmod].GetComponent<Renderer>().bounds.size.x,0,0) * (i - 1);
            newroad.transform.tag = i.ToString() ;
            newroad.transform.parent = roadgathers.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (startcontrol) {
            timer += Time.deltaTime;
            if (timer >= 10f) {
                startcontrol = false;
            }
        }
    }

    public void start() {
        startcontrol = true;
        timer = 0;
    }

    public void SetCarspeed(int value) {
        switch (value)
        {
            case 0:
                carspeed = 0.005f;
                break;
            case 1:
                carspeed = 0.01f;
                break;
            case 2:
                carspeed = 0.02f;
                break;
        }
    }

    public void Buildroad(int value)
    {
        newroadnum = value*2+2;
        Transform[] roads;
        roads = roadgathers.GetComponentsInChildren<Transform>();

        if (newroadnum > oldroadnum)
        {

                foreach (var x in roads)
                {
                    if (x.tag == oldroadnum.ToString())
                    {
                        Destroy(x.gameObject);
                    }
                }


            for (int i = oldroadnum; i <= newroadnum; i++)
            {
                if (i == 1)
                {
                    roadmod = 0;
                }
                if (i == newroadnum)
                {
                    roadmod = 2;
                }
                else
                {
                    roadmod = 1;
                }

                GameObject newroad = Instantiate(roadtypes[roadmod]);
                newroad.transform.position = startpoint.transform.position + new Vector3(roadtypes[roadmod].GetComponent<Renderer>().bounds.size.x, 0, 0) * (i - 1);
                newroad.transform.tag = i.ToString();
                newroad.transform.parent = roadgathers.transform;
                newroad.transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
                newroad.transform.localPosition = new Vector3(newroad.transform.localPosition.x, 0,-712f);
            }
            oldroadnum = newroadnum;
        }

        else {
            for (int i =oldroadnum;i>newroadnum-1;i--)
            {
                foreach (var x in roads) {
                    if (x.tag == i.ToString())
                    {
                        Destroy(x.gameObject);
                    }
                }
            }
            GameObject newroad = Instantiate(roadtypes[2]);
            newroad.transform.position = startpoint.transform.position + new Vector3(roadtypes[2].GetComponent<Renderer>().bounds.size.x, 0, 0) * (newroadnum - 1);
            newroad.transform.tag = newroadnum.ToString();
            newroad.transform.parent = roadgathers.transform;
            newroad.transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
            newroad.transform.localPosition = new Vector3(newroad.transform.localPosition.x, 0, -712f);
            oldroadnum = newroadnum;

        }
    }


    public void Setangle(float value)
    {
        roadgathers.transform.rotation = Quaternion.Euler(new Vector3(value * 12f, 0, 0));
        speedplus = value * 0.01f;
    }

    public void Setroadmaterial(int value) {
        roadmaterialtype = value;
    }
}
