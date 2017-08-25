﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ShipForSale : MonoBehaviour 
{

    private MainController mainController = MainController.mainController;

    // sort by price in future
    //private List<KeyValuePair<string, GameObject>> shipsForSale = MainController.mainController.allShips.ToList();

    private List<string> shipsForSale = MainController.mainController.allShips.Keys.ToList();
    [System.NonSerialized]
    public GameObject currentShip;
    private int currentlySelected = 0;

	void Start () 
    {
	    currentShip = Instantiate(mainController.allShips[shipsForSale[currentlySelected]], transform.position, transform.rotation) as GameObject;
        currentShip.transform.parent = transform;
	}

    public void nextShip(int number)
    {
        currentlySelected += number;

        if (currentlySelected < 0)
        {
            currentlySelected = 0;
        }

        if(currentlySelected >= shipsForSale.Count())
        {
            currentlySelected = shipsForSale.Count() - 1;
        }

        Destroy(currentShip);
        currentShip = Instantiate(mainController.allShips[shipsForSale[currentlySelected]], transform.position, transform.rotation) as GameObject;
        currentShip.transform.parent = transform;
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0f, transform.localEulerAngles.z);
    }

}
