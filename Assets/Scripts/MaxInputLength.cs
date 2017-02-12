using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MaxInputLength : MonoBehaviour 
{

	public int limit;

	void Start () 
	{
		transform.GetComponent<InputField>().characterLimit = limit;
	}

	void Update () 
	{
	
	}
}
