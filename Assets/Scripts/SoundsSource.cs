using UnityEngine;
using System.Collections;

public class SoundsSource : MonoBehaviour 
{

	public static SoundsSource soundsSource;
	public AudioClip audioClip;

	void Awake()
	{
		if(soundsSource == null)
		{
			DontDestroyOnLoad(transform.gameObject);
			soundsSource = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void PlaySound()
	{
		gameObject.GetComponent<AudioSource>().clip = audioClip;
		gameObject.GetComponent<AudioSource>().Play();
	}
}
