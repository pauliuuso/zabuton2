using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour 
{

    public float speed = 2f;
    public bool randomSpeed = false;
    public float minRandomSpeed;
    public float maxRandomSpeed;
    public bool rotateX = false;
    public bool rotateY = false;
    public bool rotateZ = false;

    void Start()
    {
        if (randomSpeed)
        {
            speed = Random.Range(minRandomSpeed, maxRandomSpeed);
        }
    }

	void FixedUpdate () 
    {
        if (rotateX) transform.localEulerAngles += Vector3.right * Time.deltaTime * speed;
        if (rotateY) transform.localEulerAngles += Vector3.up * Time.deltaTime * speed;
        if (rotateZ) transform.localEulerAngles += Vector3.forward * Time.deltaTime * speed;
	}
}
