using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour {

    private void Awake()
    {
        Check();
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        Check();
    }

   void Check()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Music");
        Delay();
        if (obj.Length > 1)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
    }
}
