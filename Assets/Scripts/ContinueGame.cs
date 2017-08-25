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
    private NewToken newToken = new NewToken();
    private string new_token;

	void Start () 
	{
        mainController = MainController.mainController;
        baseUrl = mainController.baseUrl;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		string name = username.text;
		string pass = ToSha1.convert(password.text).ToString();
        new_token = newToken.GetToken();

		if (name != "" && name != null && pass != "" && pass != null && transform.GetComponent<Button>().IsInteractable())
		{
			string url = baseUrl + "/user/login";
			WWWForm form = new WWWForm();
			form.AddField("name", name);
			form.AddField("password", pass);
            form.AddField("new_token", new_token);
			WWW www = new WWW(url, form);
			StartCoroutine(CheckUser(www));
            warningText.text = "Establishing connection...";
            transform.GetComponent<Button>().interactable = false;
		}
	}

	IEnumerator CheckUser(WWW www)
	{
		yield return www;

        // try - catch

		if(www.error == null)
		{
            if(!mainController.LoginUser(www))
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
		else
		{
            warningText.text = "Failed to connect to server: " + www.error;
            ErrorSound();
            transform.GetComponent<Button>().interactable = true;
		}
	}

    void ErrorSound()
    {
        SoundsSource.soundsSource.audioClip = "error1";
        SoundsSource.soundsSource.PlaySound();
    }

}
