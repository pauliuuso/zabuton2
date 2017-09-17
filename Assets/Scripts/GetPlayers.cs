using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetPlayers : MonoBehaviour 
{
    public Text allNames;
    public Text allGold;
    public Text connectionText;

    private MainController mainController = MainController.mainController;
    private string baseUrl = MainController.mainController.baseUrl;

	void Start () 
    {
        string userId = mainController.userObject.id;
        string url = baseUrl + "/user/getusers";
        WWWForm form = new WWWForm();
        form.AddField("id", userId);
        WWW www = new WWW(url, form);
        StartCoroutine(GetUsers(www));
	}
	
	IEnumerator GetUsers(WWW www)
    {
        yield return www;

        if (www.error == null)
        {
            if (!mainController.GetUsers(www))
            {
                // Controller didn't get OK message
                connectionText.text = "Error, try again later. " + mainController.userObject.message;
                print("controller didn't get ok message");
                ErrorSound();
            }
            else
            {
                // all is ok
                connectionText.enabled = false;
                for(int a = 0; a < mainController.playersObject.players.Count; a++)
                {
                    allNames.text += (a + 1) + ". " + mainController.playersObject.players[a].name + "\n";
                    allGold.text += mainController.playersObject.players[a].gold + "\n";
                }
            }
        }
        else
        {
            // Something went wrong while reaching server
            connectionText.text = "Error, try again later. " + www.text;
            ErrorSound();
        }
    }

    void ErrorSound()
    {
        SoundsSource.soundsSource.audioClip = "error1";
        SoundsSource.soundsSource.PlaySound();
    }

}
