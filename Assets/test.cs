using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawLine(Player.instance.hmdTransform.position, Player.instance.hmdTransform.position-Player.instance.hmdTransform.forward, Color.blue);
        RaycastHit hit;
        if(Physics.Raycast(Player.instance.hmdTransform.position, Player.instance.transform.forward, out hit, Mathf.Infinity))
        {
            //Debug.Log(Time.time + transform.tag);
            if (transform.tag.Equals("Body"))
                Debug.Log("test");
            if (transform.tag == "Body")
                Debug.Log("test2");

        } 
    }
}
