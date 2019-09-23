using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScenesController : MonoBehaviour,IPointerClickHandler 
{
    
    [Tooltip("下个场景的名字")]
    public string nextSceneName;
    public GameObject button;
    public GameObject button2;
    public void buttonchange(){
        button.SetActive(false);
        button2.SetActive(true);
    }
    public void OnPointerClick(PointerEventData eventData) {
        buttonchange();
        SceneManager.LoadScene(nextSceneName);
    }

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
