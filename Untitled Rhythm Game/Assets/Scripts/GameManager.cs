using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] spawnPoint;
    public GameObject[] notes;
    public bool gameStarted;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        StartCoroutine(PlayMusic());

    }

    void Fretboard()
    {




    }


    IEnumerator PlayMusic()
    {
        gameStarted = true;
        if (gameStarted)
        {
            
            spawnPoint[0] = Instantiate(notes[0], transform.position, transform.rotation);
            yield return new WaitForSeconds(0);
            spawnPoint[1] = Instantiate(notes[1], transform.position, transform.rotation);
            gameStarted = false;
        }



    }


}
