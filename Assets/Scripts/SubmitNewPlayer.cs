using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SubmitNewPlayer : MonoBehaviour, IPointerDownHandler
{
	public InputField username;
	public InputField password;
	public InputField email;
    public Text warningText;

    private MainController mainController;
    private string baseUrl;

	void Start () 
	{
        mainController = MainController.mainController;
        baseUrl = mainController.baseUrl;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
        string name = username.text;
        string pass = ToSha1.convert(password.text).ToString();
        string em = email.text;

		if (name != "" && name != null && pass != "" && pass != null)
		{
            string url = baseUrl + "/api/user/create";
            WWWForm form = new WWWForm();
            form.AddField("name", name);
            form.AddField("password", pass);
            form.AddField("email", em);
            WWW www = new WWW(url, form);
            StartCoroutine(CreateUser(www));
            warningText.text = "";
		}
	}

    IEnumerator CreateUser(WWW www)
    {
        yield return www;
        if(www.error == null)
        {
            if (!mainController.CreateUser(www))
            {
                warningText.text = mainController.userObject.message;
                ErrorSound();
            }
            else
            {
                if (!mainController.LoginUser(www))
                {
                    warningText.text = mainController.userObject.message;
                    ErrorSound();
                }
            }
        }
        else
        {
            warningText.text = "Failed to connect to server: " + www.error;
            ErrorSound();
        }
    }

    void ErrorSound()
    {
        SoundsSource.soundsSource.audioClip = "error1";
        SoundsSource.soundsSource.PlaySound();
    }

	void Update () 
	{
	
	}
}
