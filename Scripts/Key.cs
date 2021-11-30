using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    static public string key;

    public void is_Key(Text text) 
    {
        
        key = text.text;
        
    }
}
