using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.ComponentModel;

public class ShipInfoShop : MonoBehaviour
{
    public GameObject displayShip;
    public Text shipName;
    public Text shipCost;
    public Text shipSlots;
    public Text shipHealth;
    public Text shipType;

    [System.NonSerialized]
    public Ship currentShip;

    void Start()
    {
        currentShip = displayShip.GetComponent<ShipForSale>().currentShip.GetComponent<Ship>();
    }

    void Update()
    {
        if (shipName.text != displayShip.GetComponent<ShipForSale>().currentShip.GetComponent<Ship>().name)
        {
            currentShip = displayShip.GetComponent<ShipForSale>().currentShip.GetComponent<Ship>();
            shipName.text = currentShip.name;
            shipCost.text = "Cost: " + currentShip.cost;
            shipSlots.text = "Slots: " + currentShip.slots;
            shipHealth.text = "Health: " + currentShip.health;
            shipType.text = "Type: " + currentShip.type;
        }
    }

}
