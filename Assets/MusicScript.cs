using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour {

    private void Awake()
    {
        check();
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        check();
    }

   void check()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Music");
        if (obj.Length > 1)
        {
            Destroy(gameObject);
        }
    }


}
