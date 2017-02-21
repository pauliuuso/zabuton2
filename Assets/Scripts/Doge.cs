using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Doge : MonoBehaviour 
{
    //this is harcroded DoGe class!!!!!!
    private float randomas;
    private int movingWay;
    private float speed;
    private List<Vector3> vectors = new List<Vector3>() { Vector3.forward, Vector3.left, Vector3.up };
    private float initialSize;
    private bool growBigger = false;

	void Start () 
    {
        randomas = Random.Range(0.5f, 50f);
        movingWay = (int)Random.Range(0f, 3f);
        speed = Random.Range(0.1f, 20f);
        initialSize = Random.Range(0.2f, 10f);

        transform.localScale = new Vector3(initialSize, initialSize, initialSize);
	}

	void Update () 
    {
	    if(randomas > 0)
        {
            randomas -= 0.2f;
        }
        else
        {
            randomas = Random.Range(0.5f, 50f);
            movingWay = (int)Random.Range(0f, 2f);
            speed = Random.Range(-20f, 20f);
            randomAction();
        }

        if(growBigger)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z) + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }

        if (transform.position.y < -80f || transform.position.y > 80f || transform.position.x < -80f || transform.position.x > 80f || transform.position.z > 300f || transform.position.z < -10f)
        {
            Destroy(gameObject);
        }
	}

    void randomAction()
    {
        float ranoma = Random.Range(0f, 1f);
        if(ranoma <= 0.25f)
        {
            growBigger = true;
        }
        else if(ranoma > 0.25f && ranoma <= 0.8f)
        {
            growBigger = false;
            GameObject dogeClone = Instantiate(transform.gameObject, transform.position, transform.rotation) as GameObject;
        }
        else if (ranoma > 0.8f)
        {
            growBigger = false;
            Destroy(gameObject);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "MainCamera") Destroy(gameObject);
    }

    void FixedUpdate()
    {
        transform.Translate(vectors[movingWay] * Time.deltaTime * speed);
    }
}
