using UnityEngine;
using System.Collections;

public class DestroyDelay : MonoBehaviour 
{
    public float delay = 1f;

	void Start () 
    {
        StartCoroutine(DestroyOnDelay());
	}
	
    IEnumerator DestroyOnDelay()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
