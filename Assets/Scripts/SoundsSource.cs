using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundsSource : MonoBehaviour 
{

	public static SoundsSource soundsSource;
    public AudioClip clickSound1;
    public AudioClip errorSound1;
    public AudioClip interstellarFlight;

    public Dictionary<string, AudioClip> allSounds;
	public string audioClip;

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

    void Start()
    {
        allSounds = new Dictionary<string, AudioClip>()
        {
            {"click1", clickSound1},
            {"error1", errorSound1},
            {"interstellar", interstellarFlight}
        };
    }

	public void PlaySound()
	{
		gameObject.GetComponent<AudioSource>().clip = allSounds[audioClip];
		gameObject.GetComponent<AudioSource>().Play();
	}
}
