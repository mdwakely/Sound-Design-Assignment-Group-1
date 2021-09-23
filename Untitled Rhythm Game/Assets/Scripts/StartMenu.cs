using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Establish game objects so they can be set in the inspector
/*    public GameObject playGame = null;
    public GameObject exit = null;*/

/*    void Start()
    {
        // Establish each game object in the code
        playGame = GameObject.Find("PlayGame");
        exit = GameObject.Find("Exit");
    }*/

    // Goes to the first level (scene)
    public void PlayGame()
    {
        SceneManager.LoadScene("Level001");
    }

    // Exits the game
    public void Exit()
    {
        Application.Quit();
    }
}
