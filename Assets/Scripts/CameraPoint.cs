using UnityEngine;
using System.Collections;

public class CameraPoint : MonoBehaviour 
{
    [System.NonSerialized]
    public Vector3 startingCoords;

    void Start()
    {
        startingCoords = transform.position;
    }

}
