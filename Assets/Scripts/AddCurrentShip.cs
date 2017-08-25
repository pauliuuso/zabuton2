using UnityEngine;
using System.Collections;

public class AddCurrentShip : MonoBehaviour 
{
    private MainController mainController = MainController.mainController;
    public string shipCode = "";
	// Use this for initialization
	void Start () 
    {
        if(shipCode == "")
        {
            shipCode = mainController.userObject.shipCode;
        }

        GameObject shipClone;
        shipClone = Instantiate(mainController.allShips[shipCode], new Vector3(0f, 0f, 0f), Quaternion.Euler(new Vector3(0f, 0f, 0f))) as GameObject;
        shipClone.transform.parent = transform;
        shipClone.transform.localPosition = new Vector3(0f, 0f, 0f);
        shipClone.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        shipClone.transform.localScale = new Vector3(1f, 1f, 1f);
    }
	
}
