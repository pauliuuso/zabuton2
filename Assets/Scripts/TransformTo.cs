using UnityEngine;
using System.Collections;

public class TransformTo : MonoBehaviour 
{
    public GameObject target;
    public float smoothTime;
    public float rotationSensitivity;
    private Vector3 velocity = Vector3.zero;

	void FixedUpdate () 
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.transform.position, ref velocity, smoothTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.transform.rotation, rotationSensitivity * Time.deltaTime);
	}
}
