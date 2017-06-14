using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour {

    private void Start()
    {
        check();
        DontDestroyOnLoad(this.gameObject);
    }
    private void Awake()
    {
       
        check();
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        Yieldcheck();
    }

    private IEnumerator Yieldcheck()
    {
        yield return new WaitForSeconds(0.5f);
    }

    void check()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Music");
        if (obj.Length > 1)
        {
            Destroy(this.gameObject);
        }
    }


}
