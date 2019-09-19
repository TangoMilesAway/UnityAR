using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioControl : MonoBehaviour
{
    public AudioSource mainMenuAudio;
    public Slider audioVolume;

    // public Toggle audioToggle;
    // Start is called before the first frame update

    void Start()
    {
        mainMenuAudio=GameObject.Find("BGM").GetComponent<AudioSource>();
        audioVolume.value=mainMenuAudio.volume;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnSliderChange(){
        PlayerPrefs.SetFloat("AudioVolume",audioVolume.value);
        mainMenuAudio.volume=PlayerPrefs.GetFloat("AudioVolume",1f);
        //mainMenuAudio.volume=audioVolume.value;
    }
    public void Pause()
	{
        if(mainMenuAudio.isPlaying==true){mainMenuAudio.Pause();}
        else{mainMenuAudio.Play();}
        

        
		//Lowpass ();
		
	}
    // public void OnToggleChange(){
    //     if(audioToggle.isOn==true){
    //         mainMenuAudio.Stop();}
        

    // }
}
