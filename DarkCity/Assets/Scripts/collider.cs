using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider : MonoBehaviour {
    public GameObject canvas;
	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        canvas.SetActive(true);
    }
    private void OnCollisionEnter(Collision collision)
    {

        canvas.SetActive(true);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
