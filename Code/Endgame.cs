using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endgame : MonoBehaviour
{

    private bool inTarget = false;
    public bool gameOver = false;
    public GameObject prompt;

    public GameObject ship;

    public GameObject mainCamera;

    public GameObject cutsceneCam1;
    public GameObject cutsceneCam2;

    private AnimController animController;

    public GameObject wheelBotHome;
    public GameObject trackBotHome;
    public GameObject mainPlayerHome;

    public GameObject wheelBot;
    public GameObject trackBot;
    public GameObject mainPlayer;

    public GameObject teleportEffect;

    private void Start()
    {
        animController = ship.GetComponent<AnimController>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {

            if (inTarget)
            {
                gameOver = true;
                GameOver();
            }

        }

        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<Pickup>() != null && other.GetComponent<Pickup>().hasPickedUp)
        {

            inTarget = true;
            prompt.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.GetComponent<Pickup>() != null && other.GetComponent<Pickup>().hasPickedUp)
        {

            inTarget = false;
            prompt.SetActive(false);
        }
    }

    //If the game is over, call the sequence coroutine and deactivate the main camera
    void GameOver()
    {

        mainCamera.SetActive(false);
        prompt.SetActive(false);

        StartCoroutine(TheSequence());

    }

    private IEnumerator TheSequence()
    {

        //sets all the real characters used in the game to false. (deactivates them)
        wheelBot.SetActive(false);
        trackBot.SetActive(false);
        mainPlayer.SetActive(false);
        

        //Deactivate ship collider
        ship.GetComponentInChildren<MeshCollider>().enabled = false;

        //the first cut scene cam is activated and 3 models of the characters are also activated. These characters are placed in front of the ship to give the illusion that they were teleported there,
        //(the character name + home variables)
        cutsceneCam1.SetActive(true);
        wheelBotHome.SetActive(true);
        trackBotHome.SetActive(true);
        mainPlayerHome.SetActive(true);

        //waits one second between deactivation of each of the home characters. Gives the illusion that they are being loaded on the ship.
        yield return new WaitForSeconds(2);
        Instantiate(teleportEffect, wheelBotHome.transform.position, Quaternion.Euler(new Vector3(-90, 0)));
        wheelBotHome.SetActive(false);
        
        yield return new WaitForSeconds(1);
        Instantiate(teleportEffect, trackBotHome.transform.position, Quaternion.Euler(new Vector3(-90, 0)));
        trackBotHome.SetActive(false);
        
        yield return new WaitForSeconds(1);
        Instantiate(teleportEffect, mainPlayerHome.transform.position, Quaternion.Euler(new Vector3(-90, 0)));
        mainPlayerHome.SetActive(false);

        yield return new WaitForSeconds(1);
        cutsceneCam2.SetActive(false);

        //switches to cut scene camera 2
        yield return new WaitForSeconds(2);
        cutsceneCam1.SetActive(false);
        cutsceneCam2.SetActive(true);
        yield return new WaitForSeconds(5);

        //Loads GameOver Scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }


}
