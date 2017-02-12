using UnityEngine;
using System.Collections;

public class MenuUI : MonoBehaviour 
{
	public int currentLevel = 0;
	public GameObject[] levels;

	// Use this for initialization
	void Start () 
	{
		UpdateMenu();
	}

	public void UpdateMenu()
	{
		for(int a = 0; a < levels.Length; a++)
		{
			if(a == currentLevel)
			{
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
