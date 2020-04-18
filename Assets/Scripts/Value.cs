using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Value", menuName ="Value")]
public class Value : ScriptableObject
{
   public int value;
   
    public void print()
    {
        Debug.Log("Value of this box is :" + value);
    }
}
