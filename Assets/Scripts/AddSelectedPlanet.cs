using UnityEngine;
using System.Collections;

public class AddSelectedPlanet : MonoBehaviour 
{
    private MainController mainController = MainController.mainController;
	// Use this for initialization
	void Start () 
    {
        float scale = Random.RandomRange(2f, 5f);
        GameObject shipClone;
        shipClone = Instantiate(mainController.selectedPlanet, new Vector3(0f, 0f, 0f), Quaternion.Euler(new Vector3(0f, 0f, 0f))) as GameObject;
        shipClone.transform.parent = transform;
        shipClone.transform.localPosition = new Vector3(0f, 0f, 0f);
        shipClone.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        transform.localScale = new Vector3(scale, scale, scale);
	}
	

}
