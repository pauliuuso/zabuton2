using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SubmitNewPlayer : MonoBehaviour, IPointerDownHandler
{
	public InputField username;
	public InputField password;
	public InputField email;

	void Start () 
	{

	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (username.text != "" && username.text != null && password.text != "" && password.text != null)
		{
			print("password: " + password.text);
		}
	}

	void Update () 
	{
	
	}
}
