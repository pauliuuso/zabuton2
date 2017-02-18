using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour 
{
	public static MainController mainController;
    public string baseUrl = "http://zabuton2.local";

    // storing all user info
    [System.NonSerialized]
    public UserConnection userObject;

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

    public class UserConnection
    {
        public string message;
        public string id;
        public string text;
        public string name = "noob";
    }

}
