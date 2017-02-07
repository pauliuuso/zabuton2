using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
	public Sprite inactive;
	public Sprite active;

	void Start()
	{

	}
	
	public void OnPointerDown(PointerEventData eventData)
	{

	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		transform.GetComponent<Image>().overrideSprite = active;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		transform.GetComponent<Image>().overrideSprite = inactive;
	}

}
