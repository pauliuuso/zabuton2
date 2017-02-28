using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanetChooser : MonoBehaviour 
{
    public GameObject cameraPoint;
    public float distanceFromClosePlanet = 5f;
    public GameObject invadeUI;
    public List<GameObject> particleEffects;
    public GameObject particlePoint;

    private Ray ray;
    private Camera camera;
    private RaycastHit hit;
    private RaycastHit previousHit;

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

            }
        }


        if(Input.GetMouseButtonDown(0) && hit.transform != null)
        {
            cameraPoint.transform.position = hit.transform.position + new Vector3(distanceFromClosePlanet, 0, 0f);
            invadeUI.gameObject.SetActive(true);
            if(previousHit.transform == null || previousHit.transform.position != hit.transform.position && hit.transform.tag == "Planet")
            {
                addParticles(0);
            }
            previousHit = hit;
        }

	}

    public void addParticles(int numb)
    {
        GameObject particles = Instantiate(particleEffects[numb], particlePoint.transform.position, particlePoint.transform.rotation) as GameObject;
        particles.transform.parent = transform;
    }
}
