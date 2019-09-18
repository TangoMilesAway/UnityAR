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

    void Start()
    {
        Carspeed = 0.01f;
        Nowcarspeed = Carspeed;
        timer = 0;
        stoptime = 0.5f;

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward * 10);
        Debug.DrawLine(transform.position, transform.position + transform.forward * 10, Color.red);

        if (!isstop)
        {
            if (Random.Range(0, 1000) == 500) {
                isstop = true;
            }

            if (Physics.Raycast(ray, out hit, 10))
            {
                if (Vector3.Distance(hit.transform.position, this.transform.position) < 1f)
                {
                    Nowcarspeed = 0f;
                }
                else
                {
                    Nowcarspeed = Carspeed;
                }
            }

            if (!Physics.Raycast(ray, out hit, 10))
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
