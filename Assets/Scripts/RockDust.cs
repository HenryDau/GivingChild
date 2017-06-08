using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDust : MonoBehaviour
{
    public ParticleSystem dust;
    // Use this for initialization
    void Start()
    {
        dust = GameObject.Find("Dust").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        dust.transform.position = contact.point;
        dust.Play();
    }
}

