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
    public void OnPointerClick(PointerEventData eventData) {
        SceneManager.LoadScene(nextSceneName);
    }

    void Start()
    {
        
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
