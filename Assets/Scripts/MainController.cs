using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class MainController : MonoBehaviour 
{
	public static MainController mainController;
    public string baseUrl = "http://zabuton2.local";


    public GameObject selectedPlanet;
    [System.NonSerialized]
    public Dictionary<string, GameObject> allShips = new Dictionary<string, GameObject>();
    public GameObject EnemyObject;
    // storing all user info
    [System.NonSerialized]
    public UserConnection userObject;

    private SpecialPrint specialPrint = new SpecialPrint();

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

    void Start()
    {

        userObject = new UserConnection();
        Screen.fullScreen = true;

        GameObject[] allObjects = Resources.LoadAll<GameObject>("Prefabs");

        foreach(GameObject a in allObjects)
        {
            if(a.gameObject.tag == "Ship")
            {
                allShips.Add(a.transform.GetComponent<Ship>().shipCode, a.gameObject);
            }
        }

        print("Ship count: " + allShips.Count);

    }

    public bool LoginUser(WWW www)
    {
        userObject = JsonUtility.FromJson<UserConnection>(www.text);

        if (userObject.message == "OK")
        {
            SceneManager.LoadScene("choose_planet", LoadSceneMode.Single);
            print("login");
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CreateUser(WWW www)
    {
        userObject = JsonUtility.FromJson<UserConnection>(www.text);

        if (userObject.message == "OK")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool BuyShip(WWW www)
    {
        userObject.message = JsonUtility.FromJson<UserConnection>(www.text).message;

        if (userObject.message == "OK")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public class UserConnection
    {
        public string message;
        public string id;
        public string text;
        public string name = "noob";
        public string level;
        public string shipCode = "a2";
        public int planetPower;
        public int gold;
        public string token;
    }

}
