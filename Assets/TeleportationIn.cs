using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationIn : MonoBehaviour
{

    public bool teleportedIn=false;
    //If bottom collider hits teleporter
    private void OnTriggerEnter(Collider other)
    {
       

        if (other.gameObject.tag == "teleporter")
        {
            Debug.Log("Here");
            teleportedIn = true;
        }

    }
}
