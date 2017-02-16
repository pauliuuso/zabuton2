using UnityEngine;
using System.Collections;

public class MainController : MonoBehaviour 
{
	public static MainController mainController;

    public string baseUrl = "http://zabuton2.local";

    [System.NonSerialized]
    public string name;
    [System.NonSerialized]
    public string id;
    [System.NonSerialized]
    public string token;

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
