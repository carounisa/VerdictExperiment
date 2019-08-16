using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        bool hasPlayed = false;
        Debug.Log(other.tag);
        if(other.tag == "Player" && !hasPlayed)
        {
            GetComponent<AudioSource>().Play();
            hasPlayed = true;
        }
    }
}
