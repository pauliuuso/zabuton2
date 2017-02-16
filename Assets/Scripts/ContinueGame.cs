using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;
using System.Text;

public class ContinueGame : MonoBehaviour, IPointerDownHandler
{
	public InputField username;
	public InputField password;
    public Text warningText;

    private MainController mainController;
    private string baseUrl;
    private UserConnection userObject;

	void Start () 
	{
        mainController = MainController.mainController;
        baseUrl = mainController.baseUrl;
        userObject = new UserConnection();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		string name = username.text;
		string pass = ToSha1.convert(password.text).ToString();

		if (name != "" && name != null && pass != "" && pass != null)
		{
			string url = baseUrl + "/api/user/login";
			WWWForm form = new WWWForm();
			form.AddField("name", name);
			form.AddField("password", pass);
			WWW www = new WWW(url, form);
			StartCoroutine(createUser(www));
		}
	}

    public class UserConnection
    {
        public string message;
        public string id;
        public string text;
        public string name;
    }

	IEnumerator createUser(WWW www)
	{

		yield return www;
		if(www.error == null)
		{
            userObject = JsonUtility.FromJson<UserConnection>(www.text);

            if(userObject.message != "OK")
            {
                warningText.text = userObject.message;
                print("error: " + userObject.text);
            }
            else if(userObject.message == "OK")
            {
                loginUser();
            }
		}
		else
		{
			print("Failed to connect to server: " + www.error);
		}
	}

    public void loginUser()
    {
        mainController.name = userObject.name;
        mainController.id = userObject.id;
        print("login");
    }

	void Update () 
	{
	
	}
}
