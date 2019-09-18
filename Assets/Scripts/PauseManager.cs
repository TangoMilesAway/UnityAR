using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour {
	

	Canvas canvas;
	
	void Start()
	{
		canvas = GetComponent<Canvas>();
	}
	
	void Update()
	{

	}
	public void SetMenu(){

		canvas.enabled = !canvas.enabled;
		// Pause();
		
	}
	// public void Pause()
	// {
	// 	Time.timeScale = Time.timeScale == 0 ? 1 : 0;
	// 	//Lowpass ();
		
	// }
	public void QuitPause()
    {
		canvas.enabled = !canvas.enabled;
	}
	
	// void Lowpass()
	// {
	// 	if (Time.timeScale == 0)
	// 	{
	// 		paused.TransitionTo(.01f);
	// 	}
		
	// 	else
			
	// 	{
	// 		unpaused.TransitionTo(.01f);
	// 	}
	// }
	

}
