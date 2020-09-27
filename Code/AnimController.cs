using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{

    public Animator animator;

    Endgame endgame;
    public GameObject endingCube;

    // Start is called before the first frame update
    void Start()
    {
        endgame = endingCube.GetComponent<Endgame>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //if the game is over play the final animation.
        if (endgame.gameOver)
        {

            animator.Play("Ship");

        }
    }
}
