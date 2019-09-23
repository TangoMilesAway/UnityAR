using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarbornControler : MonoBehaviour
{
    public GameObject[] car;
    public bool isborn;
    public float cooldown;
    public float timer;
    public GameObject bornpoint;
    public GameObject endpoint;
    public int carnum;
    public bool isstart;

    public Material[] roadmaterial;
    public int roadmaterialmod;
    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(0,2f);
        isstart = false;
        carnum = 0;
        isborn = false;
        roadmaterialmod=0;
        this.GetComponent<Renderer>().material = roadmaterial[roadmaterialmod];
    }

    // Update is called once per frame
    void Update()
    {
        if (roadmaterialmod != GameObject.Find("GameControl").GetComponent<Gamecontroler>().roadmaterialtype)
        {
            roadmaterialmod = GameObject.Find("GameControl").GetComponent<Gamecontroler>().roadmaterialtype;
            this.GetComponent<Renderer>().material = roadmaterial[roadmaterialmod];
        }

        isstart = GameObject.Find("GameControl").GetComponent<Gamecontroler>().startcontrol;
        if (isstart)
        {
            if (isborn && carnum <= 4)
            {
                int i = Random.Range(0,4);
                GameObject newcar = Instantiate(car[i]);
                newcar.transform.parent = this.transform;
                newcar.transform.position = bornpoint.transform.position;
                newcar.GetComponent<Carmovecontroler>().endpoint = endpoint;
                newcar.GetComponent<Carmovecontroler>().Carspeed = GameObject.Find("GameControl").GetComponent<Gamecontroler>().carspeed;
                newcar.GetComponent<Carmovecontroler>().speedplus = GameObject.Find("GameControl").GetComponent<Gamecontroler>().speedplus;
                isborn = false;
                carnum++;
                if (carnum > 2)
                {
                    timer = Random.Range(0f, 1f);
                }
                if (carnum <= 2&& carnum>=1)
                {
                    timer = Random.Range(1f, 2f);
                }
            }

            if (carnum < 1)
            {
                timer=Random.Range(2.8f, 3f);
            }

            if (!isborn)
            {
                timer += Time.deltaTime;
                if (timer >= cooldown)
                {
                    isborn = true;
                }
            }
        }
    }

    public void carnumdown() {
        carnum--;
    }
}
