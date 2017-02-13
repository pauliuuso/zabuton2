using UnityEngine;
using System.Collections;

public class MenuUI : MonoBehaviour 
{
	public int currentLevel = 0;
	public GameObject[] levels;
	public AudioClip activeSound;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () 
	{
		audioSource = gameObject.AddComponent<AudioSource>();
		UpdateMenu();
	}

	public void UpdateMenu()
	{
		for(int a = 0; a < levels.Length; a++)
		{
			if(a == currentLevel)
			{
				if(activeSound != null)
				{
					audioSource.clip = activeSound;
					audioSource.Play();
				}
				levels[a].SetActive(true);
			}
			else
			{
				levels[a].SetActive(false);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
