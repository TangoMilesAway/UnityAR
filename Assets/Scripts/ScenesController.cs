using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesController : MonoBehaviour
{
    

    public GameObject button;
    public GameObject button2;
    public void buttonchange(){
        button.SetActive(false);
        button2.SetActive(true);
    }

    public void LoadNewScene()
    {
        //保存需要加载的目标场景
        Globe.nextSceneName = "ArScene";
        buttonchange();

        SceneManager.LoadScene("Loading");		
    }
    // public void OnPointerClick(PointerEventData eventData) {
    //     buttonchange();
    //     SceneManager.LoadScene(nextSceneName);
    // }

    void Awake()
    {       
        button.SetActive(true);
        button2.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
