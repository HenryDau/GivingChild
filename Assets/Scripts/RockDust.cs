//RockDust
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDust : MonoBehaviour
{
    public GameObject objectToSpawn; // the prefab for which to spawn

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {

        ContactPoint contact = collision.contacts[0];
        Instantiate(objectToSpawn, contact.point, Quaternion.identity);


    }
}