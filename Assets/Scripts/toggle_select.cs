using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggle_select : MonoBehaviour
{
    public GameObject wrong;
    public GameObject right;
    public void  Sel_right(bool  Selete){

        if (Selete) {

            right.SetActive(true);
            wrong.SetActive(false);
        } 

    }
        public void  Sel_wrong(bool  Selete){

        if (Selete) {
            right.SetActive(false);
            wrong.SetActive(true);

        } 

    }
    // Start is called before the first frame update
    void Start()
    {
        right.SetActive(false);
        wrong.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
