using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarbornControler : MonoBehaviour
{
    public GameObject car;
    public bool isborn;
    public float cooldown;
    public float timer;
    public GameObject bornpoint;
    public GameObject endpoint;
    public int carnum;
    Vector3 length;
    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(0,2f);

        carnum = 0;
        isborn = false;
        length = this.GetComponent<Renderer>().bounds.size;

    }

    // Update is called once per frame
    void Update()
    {
        if (isborn&&carnum<=3)
        {
            GameObject newcar = Instantiate(car);
            newcar.transform.parent = this.transform;
            newcar.transform.position = bornpoint.transform.position;
            newcar.GetComponent<Carmovecontroler>().endpoint = endpoint;
            isborn = false;
            carnum++;
            timer = Random.Range(0,2f);
        }

        if (!isborn) {
            timer += Time.deltaTime;
            if (timer >= cooldown)
            {
                isborn = true;
            }
        }
    }

    public void carnumdown() {
        carnum--;
    }
}
