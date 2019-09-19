using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeHandler : MonoBehaviour
{
    // Start is called before the first frame update
	// Use this for initialization
	void Start () 
	{
		if(GameObject.Find("EffectsSlider"))
		GameObject.Find("EffectsSlider").GetComponent<Slider>().onValueChanged.AddListener(SetVolume);
	}

	void SetVolume(float volume)
	{
		GetComponent<AudioSource>().volume = volume;
	}

	void OnDestroy()
	{
		if(GameObject.Find("EffectsSlider"))
		GameObject.Find("EffectsSlider").GetComponent<Slider>().onValueChanged.RemoveListener(SetVolume);
	}
}
