using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] spawnPoint;
    public GameObject[] notes;
    public GameObject fretOne;
    public AudioClip[] musicNotes;
    public AudioClip[] failNotes;
    public AudioSource backgroundBeat;
    public AudioSource playNotes;
    public AudioSource failClips;
    //public AudioSource beatLayer;
    public bool gameStarted;
    //public bool beatPlaying;
    private int spawnIndex;
    private int notesIndex;
    public int musicIndex = 0;
    public int failIndex = 0;
    public int maxMusic;




    void Start()
    {
        playNotes.clip = musicNotes[0];
    }




    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            backgroundBeat.Play();
            //beatPlaying = true;
            StartCoroutine(PlayMusic());
        }
        spawnIndex = Random.Range(0, spawnPoint.Length);
        notesIndex = Random.Range(0, notes.Length);
        failIndex = Random.Range(0, failNotes.Length);

        if (Input.GetKeyDown("enter"))
        {
            
            gameStarted = false;
        }
        if (musicIndex > maxMusic)
        {
            musicIndex = 0;
        }
    }


    

    public void Fretboard()
    {
        playNotes.clip = musicNotes[musicIndex];
        playNotes.Play();
        /*
        if (musicIndex == musicNotes.Length - 1)
        {
            musicIndex = 0;
        }
        else
        {
            musicIndex++;
        }
        
        
        /*
        Debug.Log("Getting to fretboard");
        for (int i = 0; i < musicNotes.Length - 1; musicIndex++)
        {
            playNotes.clip = musicNotes[i];
            playNotes.Play();
        }
        */
    }
   
    /*
    IEnumerator BeatPlay()
    {
        while (beatPlaying)
        {
            yield return new WaitForSeconds(1);
            beatLayer.Play();
        }
    }
    */


    public void FailNote()
    {
        failClips.clip = failNotes[failIndex];
        failClips.Play();
    }


    IEnumerator PlayMusic()
    {
        gameStarted = true;
        while (gameStarted)
        {

            yield return new WaitForSeconds(4);
            
            Instantiate(notes[0], transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            Instantiate(notes[0], transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            Instantiate(notes[0], transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            Instantiate(notes[0], transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            

            Instantiate(notes[2], transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            Instantiate(notes[2], transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            Instantiate(notes[2], transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            Instantiate(notes[2], transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            

            Instantiate(notes[1], transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            Instantiate(notes[1], transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            Instantiate(notes[1], transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            Instantiate(notes[1], transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            

            Instantiate(notes[3], transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            Instantiate(notes[3], transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            Instantiate(notes[3], transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            Instantiate(notes[3], transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);

            yield return new WaitForSeconds(2);
            fretOne.GetComponent<FretOne>().noteNumber = 4;

            Instantiate(notes[0], transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            Instantiate(notes[1], transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            Instantiate(notes[3], transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            Instantiate(notes[2], transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            Instantiate(notes[0], transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            Instantiate(notes[1], transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            Instantiate(notes[3], transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            Instantiate(notes[2], transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            Instantiate(notes[0], transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            Instantiate(notes[1], transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            Instantiate(notes[3], transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            Instantiate(notes[2], transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
        }



    }


}
