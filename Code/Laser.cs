using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public bool toggleFire;
    public string prompt = "Fire2";
    public Character c;

    private LineRenderer lr;

    public int delay = 5;

    RaycastHit hit;

    public GameObject laserEndEffect;
    List<GameObject> clones;

    // Start is called before the first frame update
    void Start()
    {
        if(c == null) Debug.Log("Hey assign the character field to the laser class in the editor.");
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;


        clones = new List<GameObject>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (c.getActivePlayerState())
        {
            if (toggleFire)
            {
                //toggles laser with right click
                if (Input.GetButtonDown(prompt))
                {
                    lr.enabled = !lr.enabled;
                }
            }
            else
            {
                if (Input.GetButton(prompt))
                {
                    lr.enabled = true;
                }
                else lr.enabled = false;
            }


            

        }

        //if the laser is enabled, the laser end effect will be instantiated. Only 5 copies of the effect will exist at a time.
        if (lr.enabled)
        {

            if (clones.Count >= delay)
            {

                Destroy(clones[0]);
                clones.RemoveAt(0);
            }

            clones.Add(Instantiate(laserEndEffect, hit.point, transform.rotation));
        }

        lr.SetPosition(0, transform.position);
        //RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, hit.point);
                if (lr.enabled) hit.collider.gameObject.SendMessage("HitByLaser", SendMessageOptions.DontRequireReceiver);


            }
        }
        else
        {

            lr.SetPosition(1, transform.forward * 5000);

        }
    }
}
