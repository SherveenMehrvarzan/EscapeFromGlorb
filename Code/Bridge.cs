using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public GameObject bridge;

    private bool laserHitting;
    void Start()
    {
        bridge.SetActive(false);
        laserHitting = false;
    }



    private void HitByLaser()
    {
        laserHitting = true;

    }

    private void LateUpdate()
    {
        if (laserHitting)
        {

            bridge.SetActive(true);
        }
        else
        {

            bridge.SetActive(false);
        }
        laserHitting = false;
    }

}
