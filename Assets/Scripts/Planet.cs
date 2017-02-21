using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour 
{
    [System.NonSerialized]
    public string name = "";
    public float minPlanetNameLength;
    public float maxPlanetNameLength;

    private int planetNameLength;
    private string letters1 = "aeyuio";
    private string letters2 = "qwrtplkjhgfdszxcvbnm";
	
	void Start () 
    {
        planetNameLength = (int)Random.Range(minPlanetNameLength, maxPlanetNameLength);

	    for(var a = 0; a < planetNameLength; a++)
        {
            string currentString;

            if(a % 2 == 0)
            {
                currentString = letters1;
            }
            else
            {
                currentString = letters2;
            }

            name += currentString[Random.Range(0, currentString.Length)];
            if(a == 0)
            {
                name = name.ToUpper();
            }
        }
	}


}
