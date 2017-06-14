using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustDestroy : MonoBehaviour
{
    private int i;
    // Use this for initialization
    void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        i++;
        if (i >= 120)
        {
            Destroy(gameObject);
        }
    }
}