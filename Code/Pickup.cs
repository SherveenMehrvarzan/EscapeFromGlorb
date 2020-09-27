using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject pickedUpModel;
    public bool hasPickedUp = false;
    public MessageBox pickedUpMessage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit collision)
    {
        
        if(collision.rigidbody != null)
        {
            if (collision.rigidbody.CompareTag("Pickup"))
            {
                Destroy(collision.transform.gameObject);
                hasPickedUp = true;
                pickedUpModel.SetActive(true);
                pickedUpMessage.Activate();
            }
        }
    }
}
