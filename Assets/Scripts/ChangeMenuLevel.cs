using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ChangeMenuLevel : MonoBehaviour, IPointerDownHandler
{
	public int count = 1;
	public bool increase;
	public bool gotoFirst;
	public GameObject menuCanvas;
	void Start () 
	{
	
	}
	
	public void OnPointerDown(PointerEventData eventData)
	{
		if(gotoFirst)
		{
			menuCanvas.GetComponent<MenuUI>().currentLevel = 0;
		}
		else if(increase)
		{
			menuCanvas.GetComponent<MenuUI>().currentLevel += count;
		}
		else if(!increase)
		{
			menuCanvas.GetComponent<MenuUI>().currentLevel -= count;
		}

		menuCanvas.GetComponent<MenuUI>().UpdateMenu();
	}
}
