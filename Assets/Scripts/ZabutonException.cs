using UnityEngine;
using System.Collections;
using System;

public class ZabutonException : Exception 
{
    public ZabutonException()
        :base()
    {

    }

    public ZabutonException(string message)
        :base(String.Format("Zabuton fail: " + message))
    {

    }

}
