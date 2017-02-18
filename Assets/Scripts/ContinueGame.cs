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

	void Start () 
	{
        mainController = MainController.mainController;
        baseUrl = mainController.baseUrl;
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
			StartCoroutine(CheckUser(www));
            warningText.text = "";
		}
	}

	IEnumerator CheckUser(WWW www)
	{
		yield return www;
		if(www.error == null)
		{
            if(!mainController.LoginUser(www))
            {
                warningText.text = mainController.userObject.message;
                ErrorSound();
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

}
