using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour
{

    private int rotateSpeed = 2;
	
	// Update is called once per frame
	void Update () 
    {
	    if(gameObject.transform.localEulerAngles.y <= 170f)
        {
            rotateSpeed *= -1;
        }
        else if(gameObject.transform.localEulerAngles.y >= 190f)
        {
            rotateSpeed *= -1;
        }
        gameObject.transform.Rotate(0, 0, Time.deltaTime * rotateSpeed);
    }
}
