using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potionDMG : MonoBehaviour
{
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        Pig p = other.GetComponent<Pig>();
        //p.Transformar();
    }
}
