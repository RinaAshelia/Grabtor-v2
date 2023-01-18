using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodsteps : MonoBehaviour
{
    public AudioSource footstepsSound;
    public GameObject player;

    Vector3 lastPos;
 
    void Update ()
    {
        if(player.transform.position != lastPos)
        {
            footstepsSound.enabled = true;
            Debug.Log("wir laaaaufen");
        }
        else
        {
             footstepsSound.enabled = false;
        }
    
        lastPos = player.transform.position;
    }

    // void Update()
    // {
    //     if(Input.GetKey("primary2DAxis") || Input.GetKey(KeyCode.W)) {
    //         footstepsSound.enabled = true;
    //         Debug.Log("wir laaaaufen");
    //     }
    //     else
        
    //         {
    //             footstepsSound.enabled = false;
    //         }
        
    // }
}
