using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour 
{
    public string shipCode;
    public float speed;
    public float tilt;
    public string name;
    public int cost;
    public int slots;
    public int health;
    [System.NonSerialized]
    public int power;
    public string type = "";
	// Use this for initialization
	void Start () 
    {
        power = (int)(speed * 3);
	}

}
