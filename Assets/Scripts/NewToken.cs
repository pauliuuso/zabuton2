using UnityEngine;
using System.Collections;
using System;

public class NewToken : MonoBehaviour 
{

    public string GetToken()
    {
        Guid g = Guid.NewGuid();
        string guidString = Convert.ToBase64String(g.ToByteArray());
        guidString = guidString.Replace("=", "");
        guidString = guidString.Replace("+", "");

        return guidString;
    }

}
