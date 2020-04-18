using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowResultTarget : MonoBehaviour
{
    int[] targetNumbers = new int[13] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 13, 15 };
    int target;

    [SerializeField]
    Text targetText;

    // Start is called before the first frame update
    void Start()
    {
        target = Random.Range(0, targetNumbers.Length);

        Debug.Log("Target is :" + target);

        targetText.text = target.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
