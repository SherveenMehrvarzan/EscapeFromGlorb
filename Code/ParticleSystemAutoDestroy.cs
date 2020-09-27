using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemAutoDestroy : MonoBehaviour
{
    private ParticleSystem ps;

    ParticleSystem.Particle[] arr;

    public void Start()
    {
        ps = GetComponent<ParticleSystem>();
        
    }

    public void Update()
    {
                
        if (ps)
        {
            if (!ps.IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }
}
