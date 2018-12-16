using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reload : MonoBehaviour {

    public GameObject startscreen;
    public GameObject au;
    // Use this for initialization
    void Start () {

    }
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("level0");
            gameObject.SendMessage("Startgame");

        }
    }
	// Update is called once per frame
	
}
