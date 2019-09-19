using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carmovecontroler : MonoBehaviour
{
    public GameObject endpoint;
    public float Carspeed;
    public float Nowcarspeed;
    RaycastHit hit;
    private int randomnum;
    public bool isstop;
    public float timer;
    public float stoptime;
    private Transform[] children;
    private float safedistance;
    void Start()
    {
        Nowcarspeed = Carspeed;
        timer = 0;
        stoptime = 0.5f;
        children = this.GetComponentsInChildren<Transform>();
        foreach (var child in children) {
            if (child.name == "pCube5") {
                safedistance=child.GetComponent<Renderer>().bounds.size.z;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position + new Vector3(0, 7f, 0), endpoint.transform.position + new Vector3(0, 7f, 0));
        Debug.DrawLine(this.transform.position+new Vector3(0,7f,0), endpoint.transform.position + new Vector3(0, 7f, 0), Color.red);


        if (!isstop)
        {
            if (Random.Range(0, 1000) == 500) {
                isstop = true;
            }

            if (Physics.Raycast(ray, out hit, 1000))
            {
                Debug.Log(hit.transform.tag);
                if (hit.transform.tag == "Car")
                {
                    Debug.Log(Vector3.Distance(hit.transform.position, this.transform.position));
                    Debug.Log(safedistance * 1.5f);
                    if (Vector3.Distance(hit.transform.position, this.transform.position) <= safedistance*1.5f)
                    {
                        Nowcarspeed = 0f;
                    }
                    else
                    {
                        Nowcarspeed = Carspeed;
                    }
                }
                else {
                    Nowcarspeed = Carspeed;
                }
            }

            if (!Physics.Raycast(ray, out hit, 1000))
            {
                Nowcarspeed = Carspeed;
            }
        }

        if (isstop) {
            Nowcarspeed = 0f;
            timer += Time.deltaTime;
            if (timer >= stoptime)
            {
                isstop = false;
                Nowcarspeed = Carspeed;
                timer = 0;
            }
        }


        this.transform.LookAt(endpoint.transform);
        this.transform.position = Vector3.Lerp(this.transform.position, endpoint.transform.position, Nowcarspeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Destoryera") {
            Destroy(this.gameObject);
        }
    }
}
