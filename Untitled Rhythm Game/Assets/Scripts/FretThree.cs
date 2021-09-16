using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FretThree : MonoBehaviour
{

    public GameObject manager;
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
            manager.GetComponent<GameManager>().musicIndex++;
        }
    }
    
    private void Update()
    {
        if (hitNote && Input.GetKeyDown(KeyCode.D))
        {
            manager.GetComponent<GameManager>().Fretboard();
            Destroy(noteBlock.gameObject);
            hitNote = false;
            Debug.Log("Key pressed");

        }
    }



}