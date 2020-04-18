using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Value value;

    int points;

    // Start is called before the first frame update
    void Start()
    {
        points = value.value;
    }

}
