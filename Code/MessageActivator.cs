using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageActivator : MonoBehaviour
{
    public MessageBox msg;
    private Character c;
    bool hasActivated = false;

    private void Start()
    {
        c = GetComponent<Character>();
    }

    // Start is called before the first frame update
    void Update()
    {
        if (!hasActivated && c.getActivePlayerState()) {
            msg.Activate();
            hasActivated = true;
        }
    }
}
