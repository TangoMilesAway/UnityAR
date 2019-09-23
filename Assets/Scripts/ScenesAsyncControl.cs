﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScenesAsyncControl : MonoBehaviour,IPointerClickHandler 
{
    public GameObject ARCamara;
    public GameObject Pos;
    

    [Tooltip("下个场景的名字")]
    public string nextSceneName;
    public void OnPointerClick(PointerEventData eventData) {
        ArMove();
        SceneManager.LoadScene(nextSceneName);
    }
    public void ArMove(){

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
    public void CameraMove(){
        Pos.transform.position = Vector3.MoveTowards(transform.position,ARCamara.transform.position,Time.deltaTime*2);   

    }
}
