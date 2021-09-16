using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frets : MonoBehaviour
{

    public GameObject manager;
    


    // Start is called before the first frame update
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Note")
        {
            Destroy(other.gameObject);
            Debug.Log("Key pressed");
            manager.GetComponent<GameManager>().Fretboard();
            
            
        }
    }


}
