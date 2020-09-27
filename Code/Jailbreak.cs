using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jailbreak : MonoBehaviour
{

    public GameObject barrier;
    public GameObject placeholderWheelBot;
    public GameObject realWheelBot;

    private bool laserHitting;

    void Start()
    {
        barrier.SetActive(true);
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

            barrier.SetActive(false);
            Revive();
        }
        else
        {

            barrier.SetActive(true);
        }
        laserHitting = false;
    }

    void Revive()
    {

        placeholderWheelBot.SetActive(false);
        realWheelBot.SetActive(true);
    }
}
