using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackBotTripwire : MonoBehaviour
{
    public GameObject placeholderTrackBot;
    public GameObject realTrackBot;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character")){

            Revive();
        }

    }

    void Revive()
    {

        placeholderTrackBot.SetActive(false);
        realTrackBot.SetActive(true);
    }
}
