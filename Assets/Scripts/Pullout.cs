using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pullout : MonoBehaviour
{
    public GameObject endpoint;
    public float speed;
    public Image black;
    public bool isstart;
    public float timer;
    void Start()
    {
        isstart = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, endpoint.transform.position, speed);
        if (isstart) {
            timer += Time.deltaTime*50f;
            black.rectTransform.localScale = new Vector3(timer,timer,0);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Start") {
            isstart = true;
        }
    }
}
