using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDust : MonoBehaviour
{
    
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
        ParticleSystem dust;
        dust = GameObject.Find("Dust").GetComponent<ParticleSystem>();
        ContactPoint contact = collision.contacts[0];
        dust.transform.position = contact.point;
        dust.Play();
        
        
    }
}

