using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamecontroler : MonoBehaviour
{
    public GameObject road;
    public GameObject startpoint;
    public int roadnum;
    public bool startcontrol;
    public float timer;
    public float runtime;
    public float carspeed;
    
    // Start is called before the first frame update
    void Start()
    {
        startcontrol = false;
        for (int i = 1; i <= roadnum; i++)
        {
            GameObject newroad = Instantiate(road);
            newroad.transform.position = startpoint.transform.position + new Vector3(road.GetComponent<Renderer>().bounds.size.x,0,0) * (i - 1);
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

}
