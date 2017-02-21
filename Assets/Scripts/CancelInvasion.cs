using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CancelInvasion : MonoBehaviour, IPointerDownHandler
{
    public GameObject cameraPoint;
    public GameObject parentUI;

	void Start () 
    {
	
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(MoveBack());
    }

    IEnumerator MoveBack()
    {
        yield return new WaitForSeconds(0.1f);
        cameraPoint.transform.position = cameraPoint.GetComponent<CameraPoint>().startingCoords;
        parentUI.gameObject.SetActive(false);
    }

}
