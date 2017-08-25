using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class NextShip : MonoBehaviour, IPointerDownHandler
{
    public GameObject displayShip;
    public int value;

    public void OnPointerDown(PointerEventData eventData)
    {
        displayShip.GetComponent<ShipForSale>().nextShip(value);
    }

}
