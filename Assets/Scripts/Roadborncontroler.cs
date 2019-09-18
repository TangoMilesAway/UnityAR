using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roadborncontroler : MonoBehaviour
{
    public GameObject road;
    public GameObject startpoint;
    public int roadnum;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= roadnum; i++)
        {
            GameObject newroad = Instantiate(road);
            newroad.transform.position = startpoint.transform.position + new Vector3(road.GetComponent<Renderer>().bounds.size.x,0,0) * (i - 1);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
