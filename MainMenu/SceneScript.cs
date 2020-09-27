using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneScript : MonoBehaviour
{

    public void Play()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    public void Exit()
    {

        Application.Quit();
    }
}
