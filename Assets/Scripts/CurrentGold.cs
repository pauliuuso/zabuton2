using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CurrentGold : MonoBehaviour 
{
    private MainController mainController = MainController.mainController;
	// Use this for initialization
	void Start () 
    {
        transform.GetComponent<Text>().text = "Gold: " + mainController.userObject.gold;
	}
}
