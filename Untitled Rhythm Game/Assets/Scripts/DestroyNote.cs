using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyNote : MonoBehaviour
{
    public GameObject manager;
    public int failCount = 0;
    public int failLimit;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Note")
        {
            Destroy(other.gameObject);
            failCount++;
            if (failCount >= failLimit)
            {
                Debug.Log("Game Over");
            }
        }
    }
    


}
