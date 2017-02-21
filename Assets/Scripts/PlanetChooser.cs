using UnityEngine;
using System.Collections;

public class PlanetChooser : MonoBehaviour 
{
    public GameObject cameraPoint;
    public float distanceFromClosePlanet = 5f;
    public GameObject invadeUI;

    private Ray ray;
    private Camera camera;
    private RaycastHit hit;

	void Start () 
    {
        camera = transform.FindChild("Camera").GetComponent<Camera>();
	}

	void Update () 
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            if(hit.transform.tag == "Planet")
            {

            }
            else
            {
                print("hit");
            }
        }


        if(Input.GetMouseButtonDown(0) && hit.transform != null)
        {
            cameraPoint.transform.position = hit.transform.position + new Vector3(distanceFromClosePlanet, 0, 0f);
            invadeUI.gameObject.SetActive(true);
        }

	}
}
