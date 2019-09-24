﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSceneFinal : MonoBehaviour
{
    

    public void LoadNewScene()
    {
        //保存需要加载的目标场景
        Globe.nextSceneName = "Final";

        SceneManager.LoadScene("Loading");		
    }
    // public void OnPointerClick(PointerEventData eventData) {
    //     buttonchange();
    //     SceneManager.LoadScene(nextSceneName);
    // }

    void Awake()
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
