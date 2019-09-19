using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountCar : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject UI;
    void Start()
    {
        UI = GameObject.Find("UI");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Car") {

            UI.GetComponent<Uicontroler>().carpassnumup();
        }
    }
}
