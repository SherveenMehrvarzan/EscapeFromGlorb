using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDestroy : MonoBehaviour
{

    public GameObject explosionEffect;

    public void HitByLaser()
    {

        Explode();               
    }

    private void Explode()
    {

        Instantiate(explosionEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }

    
}
