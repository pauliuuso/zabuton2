using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanetSpawner : MonoBehaviour 
{
    public GameObject planet;
    public int minPlanetCount;
    public int maxPlanetCount;
    public float minPlanetSize;
    public float maxPlanetSize;

    private List<Transform> spawnPoints = new List<Transform>();
    private int planetCount;
    private GameObject planetClone;

	void Start () 
    {
        planetCount = (int)Random.Range(minPlanetCount, maxPlanetCount);
        foreach(Transform child in transform)
        {
            if(child.name == "Spawn")
            {
                spawnPoints.Add(child);
            }
        }

        for(int a = 0; a < planetCount; a++)
        {
            int selectedPoint = Random.Range(0, spawnPoints.Count);
            float planetSize = Random.Range(minPlanetSize, maxPlanetSize);
            planet.transform.localScale = new Vector3(planetSize, planetSize, planetSize);
            planetClone = Instantiate(planet, spawnPoints[selectedPoint].position, Quaternion.identity) as GameObject;
            spawnPoints.RemoveAt(selectedPoint);
        }
        
	}
	

	void Update () {
	
	}
}
