using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCollider : MonoBehaviour {

    
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            Debug.Log(other.tag);
            gameObject.SendMessage("EnemySees");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        gameObject.SendMessage("Disapper");
    }
}
