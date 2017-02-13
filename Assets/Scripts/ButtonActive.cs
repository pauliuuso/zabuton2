using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonActive : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
	public Sprite inactive;
	public Sprite active;
	public AudioClip clickSound;

	void Start()
	{
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		transform.GetComponent<Image>().overrideSprite = inactive;
		if(clickSound != null)
		{
			SoundsSource.soundsSource.audioClip = clickSound;
			SoundsSource.soundsSource.PlaySound();
		}
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
