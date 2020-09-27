using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject mainPlayer;
    //public GameObject player2;
    //public GameObject player3;

    private GameObject cameraTarget;


    public float yOffset = 2f;
    public float zOffset = -3f;
    private Vector3 offset;

    GameObject[] characters;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        

        Activate(mainPlayer);

        cameraTarget = mainPlayer;
        offset = new Vector3(0, yOffset, zOffset);
        CameraFollow(cameraTarget);

        timer = 0;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;


        

        //Camera moving smoothly
        foreach(GameObject c in GameObject.FindGameObjectsWithTag("Character"))
        {

            if(c.GetComponent<Character>().getActivePlayerState() && timer < 1)
            {

                c.GetComponent<Character>().enabled = false;
            }
        }
        //Camera moving smoothly
        foreach (GameObject c in GameObject.FindGameObjectsWithTag("Character"))
        {

            if (c.GetComponent<Character>().getActivePlayerState() && timer < 1)
            {

                Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, (c.transform.position + offset), .1f);
            }
        }
    }

    void Update()
    {
        //Camera moving smoothly
        foreach (GameObject c in GameObject.FindGameObjectsWithTag("Character"))
        {

            if (c.GetComponent<Character>().getActivePlayerState() && timer < 1)
            {

                Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, (c.transform.position + offset), .1f);
            }
        }
        //switches character when ctrl is pressed. Makes them the active character
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {

            characters = GameObject.FindGameObjectsWithTag("Character");

            //Sets player to active
            for (int i = 0; i < characters.Length; i++)
            {

                

                if (characters[i].GetComponent<Character>().getActivePlayerState())
                {
                    if (i == characters.Length - 1)
                    {

                        i = -1;
                    }
                    GameObject character = characters[i + 1];
                    Activate(character);
                    break;
                }
            }

            //sets timer to 0
            if (characters.Length != 1) { 
                timer = 0;
            }

            //disables movement
            foreach (GameObject c in GameObject.FindGameObjectsWithTag("Character"))
            {

                c.GetComponent<Character>().setCanMove(false);
            }
        }
    }

    private void LateUpdate()
    {
        //1 sec of disabling Camera Follow every switch to allow of camera to move smoothly
        if (timer > 1)
        {
            CameraFollow(cameraTarget);

            //re-enables movement
            foreach (GameObject character in GameObject.FindGameObjectsWithTag("Character"))
            {

                character.GetComponent<Character>().setCanMove(true);
            }
        }
    }

    //sets the selected character to active while deactivating all the other ones
    private void Activate(GameObject player)
    {
        
        player.SendMessage("SetActivePlayer", true);

        GameObject[] characters = GameObject.FindGameObjectsWithTag("Character");

        cameraTarget = player;

        foreach(GameObject character in characters)
        {
            if (!(player == character))
            {
                character.SendMessage("SetActivePlayer", false);

            }
        }


    }

    //Makes the camera follow the selected character at a certain offset.
    private void CameraFollow(GameObject player)
    {
        if(Camera.main != null)
        {
            Camera.main.transform.position = player.transform.position + offset;
            Camera.main.transform.eulerAngles = new Vector3(40, 0, 0);
        }
    }

    
}
