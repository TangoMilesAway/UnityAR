using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carnumdown : MonoBehaviour
{
    public GameObject road;   
    void Start()
    {
        road = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Car") {
            road.GetComponent<CarbornControler>().carnumdown();
        }
    }
}
