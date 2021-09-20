using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FretOne : MonoBehaviour
{

    public GameObject manager;
    public int noteNumber = 0;
    bool hitNote;
    GameObject noteBlock;


    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Note")
        {
            hitNote = true;
            noteBlock = other.gameObject;

        }
        else hitNote = false;
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Note")
        {
            hitNote = false;
            manager.GetComponent<GameManager>().FailNote();
            
        }
    }
    
    public void Update()
    {
        if (hitNote && Input.GetKeyDown(KeyCode.A))
        {
            manager.GetComponent<GameManager>().musicIndex = noteNumber;
            manager.GetComponent<GameManager>().Fretboard();
            Destroy(noteBlock.gameObject);
            hitNote = false;
            Debug.Log("Key pressed");

        }
    }



}