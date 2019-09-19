using UnityEngine;
using System.Collections;

public class Printer : MonoBehaviour
{

    public Material[] material;

    public float minY = 0;
    public float maxY = 2;
    public float duration = 5;

    // Update is called once per frame
    void Update()
    {
        float y = Mathf.Lerp(minY, maxY, Time.time / duration);
        for (int i = 0; i < material.Length; i++)
        {
            material[i].SetFloat("_ConstructY", y);
        }
        
    }
}
