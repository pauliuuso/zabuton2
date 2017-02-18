using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayPlayerName : MonoBehaviour 
{
    private MainController mainController = MainController.mainController;
    
	void Start () 
    {
        transform.GetComponent<Text>().text = mainController.userObject.name;
	}
	

}
