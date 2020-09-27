using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public void Menu()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {

        Application.Quit();
    }
}
