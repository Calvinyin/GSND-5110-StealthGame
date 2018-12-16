using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamestart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public GameObject au;
    public GameObject startscreen;
	
    public void Startgame()
    {
        startscreen.SetActive(false);
        au.SetActive(true);
    }

	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            Startgame();
        }
    }
}
