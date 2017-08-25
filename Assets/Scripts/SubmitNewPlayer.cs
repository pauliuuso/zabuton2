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
    private NewToken newToken = new NewToken();
    private string new_token;

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
        new_token = newToken.GetToken();

		if (name != "" && name != null && pass != "" && pass != null && transform.GetComponent<Button>().IsInteractable())
		{
            string url = baseUrl + "/user/create";
            WWWForm form = new WWWForm();
            form.AddField("name", name);
            form.AddField("password", pass);
            form.AddField("email", em);
            form.AddField("new_token", new_token);
            WWW www = new WWW(url, form);
            StartCoroutine(CreateUser(www));
            warningText.text = "Establishing connection...";
            transform.GetComponent<Button>().interactable = false;
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
                transform.GetComponent<Button>().interactable = true;
            }
            else
            {
                if (!mainController.LoginUser(www))
                {
                    warningText.text = mainController.userObject.message;
                    ErrorSound();
                    transform.GetComponent<Button>().interactable = true;
                }
                else
                {
                    mainController.userObject.token = new_token;
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
