using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initiation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject initiation;
    void Awake(){
        DontDestroyOnLoad(initiation);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
