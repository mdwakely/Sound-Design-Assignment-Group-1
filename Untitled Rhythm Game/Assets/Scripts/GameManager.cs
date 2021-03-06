using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] spawnPoint;
    public GameObject[] notes;
    public GameObject fretOne;
    public GameObject fretTwo;
    public GameObject fretThree;
    public GameObject fretFour;
    
    public AudioClip[] musicNotes;
    public AudioClip[] failNotes;
    public AudioClip[] comboNotes;
    public AudioClip[] comboCheer;
    public AudioSource backgroundBeat;
    public AudioSource playNotes;
    public AudioSource failClips;
    public AudioSource crowdCheer;
    public AudioSource crowdBoo;
    public AudioSource comboDing;
    public AudioSource extraCheer;
    public Canvas pauseScreen;
    public Canvas inGameCanvas;
    public Text score;
    public Text combo;
    public Text ready;
    //public AudioSource beatLayer;
    public bool gameStarted;
    public float waitTime;
    //public bool beatPlaying;
    private int spawnIndex;
    private int notesIndex;
    public int musicIndex = 0;
    public int failIndex = 0;
    public int failLimit = 0;
    int comboNoteIndex = 0;
    int points = 25;
    int currentPoints;
    int comboMulti = 1;
    int comboIndex = 0;
    int comboCheerIndex = 0;
    public int maxMusic;
    FretOne fretOneNote;
    FretTwo fretTwoNote;
    FretThree fretThreeNote;
    FretFour fretFourNote;



    void Start()
    {
        pauseScreen.enabled = false;
        playNotes.clip = musicNotes[0];
        fretOneNote = fretOne.GetComponent<FretOne>();
        fretTwoNote = fretTwo.GetComponent<FretTwo>();
        fretThreeNote = fretThree.GetComponent<FretThree>();
        fretFourNote = fretFour.GetComponent<FretFour>();
        StartCoroutine(PlayMusic());
        backgroundBeat.Play();
        currentPoints = 0;
        score.text = ("Score: " + currentPoints);
        combo.text = ("Combo: " + comboMulti + "x");
    }




    void Update()
    {

        
            
            //beatPlaying = true;
            
        
        spawnIndex = Random.Range(0, spawnPoint.Length);
        notesIndex = Random.Range(0, notes.Length);
        failIndex = Random.Range(0, failNotes.Length);
        comboNoteIndex = Random.Range(0, comboNotes.Length);


        if (Input.GetKeyDown("escape"))
        {
            Time.timeScale = 0;
            pauseScreen.enabled = true;
            backgroundBeat.Pause();
            
        }
        if (musicIndex > maxMusic)
        {
            musicIndex = 0;
        }
        if (comboCheerIndex >= comboCheer.Length)
        {
            comboCheerIndex = 0;
        }
    }

    public void Resume()
    {
        pauseScreen.enabled = false;
        Time.timeScale = 1;
        backgroundBeat.Play();
    }

    public void Exit()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(0);
    }

    public void Fretboard()
    {
        playNotes.clip = musicNotes[musicIndex];
        playNotes.Play();
        currentPoints = currentPoints + points;
        score.text = ("Score: " + (currentPoints * comboMulti));
        if (comboIndex == 10)
        {
            comboMulti++;
            comboIndex = 0;
            comboDing.clip = comboNotes[comboNoteIndex];
            comboDing.Play();
            comboNoteIndex++;
            extraCheer.clip = comboCheer[comboCheerIndex];
            extraCheer.Play();
            comboCheerIndex++;
        }
        else
        {
            comboIndex++;
        }
        if (comboNoteIndex > 2)
        {
            comboNoteIndex = 0;
        }
        combo.text = ("Combo: " + comboMulti + "x");
        if (crowdBoo.isPlaying)
        {
            failLimit--;
            if (failLimit == 0)
            {
                crowdBoo.Stop();
            }
        }
        
    }
        
    



    public void FailNote()
    {
        failClips.clip = failNotes[failIndex];
        failClips.Play();
        comboMulti = 1;
        combo.text = ("Combo: " + comboMulti + "x");
        failLimit++;
        comboCheerIndex = 0;
        if (extraCheer.isPlaying)
        {
            extraCheer.Stop();
        }
        if (!crowdBoo.isPlaying && failLimit == 8)
        {
            crowdBoo.Play();
        }
        
    }


    IEnumerator PlayMusic()
    {
        fretFourNote.noteNumber = 1;
        fretThreeNote.noteNumber = 2;
        fretTwoNote.noteNumber = 3;
        fretOneNote.noteNumber = 0;
        waitTime = 0.5f;
            yield return new WaitForSeconds(3.8f);
        ready.enabled = false;
            Instantiate(notes[3], transform.position, transform.rotation);
            yield return new WaitForSeconds(waitTime);
            Instantiate(notes[3], transform.position, transform.rotation);
            yield return new WaitForSeconds(waitTime);
            Instantiate(notes[2], transform.position, transform.rotation);
            yield return new WaitForSeconds(waitTime);
            Instantiate(notes[2], transform.position, transform.rotation);
            yield return new WaitForSeconds(waitTime);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.6f);

        //change notes

        fretTwoNote.noteNumber = 13;
        fretThreeNote.noteNumber = 11;
        fretFourNote.noteNumber = 12;

        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.75f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.75f);
        fretTwoNote.noteNumber = 13;
        fretThreeNote.noteNumber = 11;
        fretFourNote.noteNumber = 12;
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.75f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.75f); 
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.75f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.75f); 
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.75f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.75f); 
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.75f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.75f); 
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.75f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.75f); 
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.75f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.75f); 
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.75f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.75f);

        //change notes
        
        

        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(1.5f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(1.5f);
        fretFourNote.noteNumber = 9;
        fretThreeNote.noteNumber = 8;
        fretTwoNote.noteNumber = 10;
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(1.5f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(1.5f); 
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(1.5f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(1.5f);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(1.5f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(1.5f); 
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(1.5f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(1.5f);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(1.5f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(1.5f); 
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(1.5f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(1.5f);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(1.5f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(1.5f);

        //change notes
        

        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        fretFourNote.noteNumber = 20;
        fretThreeNote.noteNumber = 19;
        fretTwoNote.noteNumber = 21;
        fretOneNote.noteNumber = 18;
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f); 
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f); 
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f); 
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f); 
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f); 
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f); 
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f); 
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f); 
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f); 
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f); 
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f); 
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f); 
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f); 
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f); 
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f); 
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);

        //change notes
        

        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        fretFourNote.noteNumber = 16;
        fretThreeNote.noteNumber = 15;
        fretTwoNote.noteNumber = 17;
        fretOneNote.noteNumber = 14;
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);

        //change notes
       

        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        fretFourNote.noteNumber = 6;
        fretThreeNote.noteNumber = 5;
        fretTwoNote.noteNumber = 7;
        fretOneNote.noteNumber = 4;
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[3], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[1], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[2], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);
        Instantiate(notes[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(waitTime);

    }
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

}
