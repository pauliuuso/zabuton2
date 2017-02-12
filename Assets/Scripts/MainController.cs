using UnityEngine;
using System.Collections;

public class MainController : MonoBehaviour 
{
	public static MainController mainController;

	void Awake()
	{
		if(mainController == null)
		{
			DontDestroyOnLoad(transform.gameObject);
			mainController = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

}
