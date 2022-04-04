using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homingcornthing : MonoBehaviour
{
    public GameObject poly;
    void OnAwake()
    {
        poly = GameObject.Find("polygoon");
    }

    void Update()
    {
        
    }
}
