using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdJump : MonoBehaviour
{
    
    public float timer;
    public float speed = 2f;
    public float maxJumpTime = 1f;
    public bool isJumping;
    public float minJump = 0.5f;
    public bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        maxJumpTime = Random.Range(minJump, maxJumpTime);
    }

    // Update is called once per frame
    void Update()
    {

        
            if (isJumping)
            {
                transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            }
            else
            {
                transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
            }
            timer += Time.deltaTime;
            if (timer > maxJumpTime)
            {
                timer = 0;
                isJumping = !isJumping;
            }
        
    }
}
