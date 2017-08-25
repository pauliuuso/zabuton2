using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BuyShip : MonoBehaviour, IPointerDownHandler
{
    private MainController mainController = MainController.mainController;
    private NewToken newToken = new NewToken();
    private string new_token;
    public Text warningText;

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if (mainController.userObject.gold >= transform.parent.GetComponent<ShipInfoShop>().currentShip.cost)
        {
            warningText.text = "";
            mainController.userObject.gold -= transform.parent.GetComponent<ShipInfoShop>().currentShip.cost;
            string id = mainController.userObject.id;
            string old_token = mainController.userObject.token;
            new_token = newToken.GetToken();
            int gold = mainController.userObject.gold;
            string shipCode = transform.parent.GetComponent<ShipInfoShop>().currentShip.shipCode;

            string url = mainController.baseUrl + "/user/buyship";
            WWWForm form = new WWWForm();
            form.AddField("id", id);
            form.AddField("old_token", old_token);
            form.AddField("new_token", new_token);
            form.AddField("gold", gold);
            form.AddField("shipCode", shipCode);
            WWW www = new WWW(url, form);
            StartCoroutine(TryBuyingShip(www));
            transform.GetComponent<Button>().interactable = false;
        }
        else
        {
            warningText.text = "You don't have enough gold!";
        }
    }

    IEnumerator TryBuyingShip(WWW www)
    {
        yield return www;

        if(www.error == null)
        {
            if(!mainController.BuyShip(www))
            {
                warningText.text = mainController.userObject.message;
                mainController.userObject.gold += transform.parent.GetComponent<ShipInfoShop>().currentShip.cost;
                ErrorSound();
                transform.GetComponent<Button>().interactable = true;
            }
            else
            {
                mainController.userObject.shipCode = transform.parent.GetComponent<ShipInfoShop>().currentShip.shipCode;
                mainController.userObject.token = new_token;
                transform.GetComponent<Button>().interactable = true;
                SceneManager.LoadScene("battle_preparation", LoadSceneMode.Single);
            }
        }
        else
        {
            mainController.userObject.gold -= transform.parent.GetComponent<ShipInfoShop>().currentShip.cost;
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
