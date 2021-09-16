using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] spawnPoint;
    public GameObject[] notes;
    public AudioClip[] musicNotes;
    public AudioSource backgroundBeat;
    public AudioSource playNotes;
    public bool gameStarted;
    private int spawnIndex;
    private int notesIndex;
    public int musicIndex = 0;


    void Start()
    {
        playNotes.clip = musicNotes[0];
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

    public void Fretboard()
    {
        Debug.Log("Getting to fretboard");
        for (int i = 0; i < musicNotes.Length - 1; musicIndex++)
        {
            playNotes.clip = musicNotes[i];
            playNotes.Play();
        }
    }
    


    IEnumerator PlayMusic()
    {
        gameStarted = true;
        if (gameStarted)
        {
            spawnPoint[spawnIndex] = Instantiate(notes[notesIndex], transform.position, transform.rotation);
            yield return new WaitForSeconds(3);
        }



    }


}
