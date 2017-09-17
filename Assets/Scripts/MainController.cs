using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;
using System.Linq;

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
    [System.NonSerialized]
    public PlayersObject playersObject = new PlayersObject();

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

    public bool GetUsers(WWW www)
    {
        JsonUtility.FromJsonOverwrite(www.text, playersObject);
        playersObject.players = playersObject.players.OrderByDescending(x => x.gold).ToList();

        if (playersObject.message == "OK")
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

    [System.Serializable]
    public class Players
    {
        public string name;
        public int gold;
        public string id;
    }

    [System.Serializable]
    public class PlayersObject
    {
        public string message;
        public List<Players> players;
    }

}
