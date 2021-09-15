using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] spawnPoint;
    public GameObject[] notes;
    public bool gameStarted;
    private int spawnIndex;
    private int notesIndex;


    void Start()
    {
        
    }




    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            StartCoroutine(PlayMusic());
        }
        spawnIndex = Random.Range(0, spawnPoint.Length);
        notesIndex = Random.Range(0, notes.Length);
        if (Input.GetKeyDown("enter"))
        {
            gameStarted = false;
        }
    }

    


    IEnumerator PlayMusic()
    {
        gameStarted = true;
        while (gameStarted)
        {
            spawnPoint[spawnIndex] = Instantiate(notes[notesIndex], transform.position, transform.rotation);
            yield return new WaitForSeconds(3);
        }



    }


}
