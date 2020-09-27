using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public bool activePlayer = false;
    public bool canMove = false;


    public void SetActivePlayer(bool val)
    {
        activePlayer = val;

    }

    public bool getActivePlayerState()
    {

        return activePlayer;
    }

    public void setCanMove(bool val)
    {

        canMove = val;
    }


}
