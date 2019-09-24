using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoController : MonoBehaviour
{
    public GameObject information;
    public AudioSource explainAudio;
    public Slider effectVolume;

    // Start is called before the first frame update
    void Start()
    {
        information.SetActive(false);
        explainAudio=GameObject.Find("Explain").GetComponent<AudioSource>();
        effectVolume.value=explainAudio.volume;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetInfo(){
        information.SetActive(true);
    }
    public void CloseInfo(){
        explainAudio.Stop();
        information.SetActive(false);

    }
    public void OnSliderChange(){
        PlayerPrefs.SetFloat("AudioVolume",effectVolume.value);
        explainAudio.volume=PlayerPrefs.GetFloat("AudioVolume",1f);
        //mainMenuAudio.volume=audioVolume.value;
    }
    public void Pause()
	{
        if(explainAudio.isPlaying==true){explainAudio.Pause();}
        else{explainAudio.Play();}
    }

}
