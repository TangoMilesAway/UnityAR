using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PanelControl : MonoBehaviour
{
    public GameObject Conclusion1;
    public GameObject Conclusion2;
    public GameObject Conclusion3;
    public GameObject Test1;
    public GameObject Test2;
    public GameObject Final;

    // public GameObject t1;
    // public GameObject t2;
    // public GameObject Wrong;
    

    // Start is called before the first frame update
    void Start()
    {
        Conclusion1.SetActive(true);
        Conclusion2.SetActive(false);
        Conclusion3.SetActive(false);
        Test1.SetActive(false);
        Test2.SetActive(false);
        Final.SetActive(false);
        // Wrong.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ShowC1()
    {
        Conclusion1.SetActive(true);
        Conclusion2.SetActive(false);
        Conclusion3.SetActive(false);
        Test1.SetActive(false);
        Test2.SetActive(false);
        Final.SetActive(false);
    }
    public void ShowC2(){
        Conclusion1.SetActive(false);
        Conclusion2.SetActive(true);
        Conclusion3.SetActive(false);
        Test1.SetActive(false);
        Test2.SetActive(false);
        Final.SetActive(false);
    }
    public void ShowC3(){
        Conclusion1.SetActive(false);
        Conclusion2.SetActive(false);
        Conclusion3.SetActive(true);
        Test1.SetActive(false);
        Test2.SetActive(false);
        Final.SetActive(false);
    }
    public void ShowT1(){
        Conclusion1.SetActive(false);
        Conclusion2.SetActive(false);
        Conclusion3.SetActive(false);
        Test1.SetActive(true);
        Test2.SetActive(false);
        Final.SetActive(false);
    }
    public void ShowT2(){
        Conclusion1.SetActive(false);
        Conclusion2.SetActive(false);
        Conclusion3.SetActive(false);
        Test1.SetActive(false);
        Test2.SetActive(true);
        Final.SetActive(false);
    }
    public void ShowFinal(){
        Conclusion1.SetActive(false);
        Conclusion2.SetActive(false);
        Conclusion3.SetActive(false);
        Test1.SetActive(false);
        Test2.SetActive(false);
        Final.SetActive(true);
    }
    public void QuitApplication()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying=false;
        #else
            Application.Quit();
        #endif
    }
}
