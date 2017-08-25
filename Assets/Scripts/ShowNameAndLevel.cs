using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowNameAndLevel : MonoBehaviour 
{
    private MainController mainController = MainController.mainController;
	// Use this for initialization
	void Start () 
    {
        transform.GetComponent<Text>().text = mainController.userObject.name + " Level: " + mainController.userObject.level;
	}
}
