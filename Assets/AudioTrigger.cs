using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        bool hasPlayed = false;
        if(other.tag == "Player" && !hasPlayed)
        {
            Debug.Log("is playing");
            GetComponent<AudioSource>().Play();
            hasPlayed = true;
        }
    }
}
