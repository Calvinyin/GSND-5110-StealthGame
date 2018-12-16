using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControler : MonoBehaviour
{


    [Header("Cam Setting")]
    public Camera cam;
    public float camPositionLerpSpeed=0.8f;
    public float camRotationLerpSpeed=0.8f;
    public LayerMask terrainLayer;
    public NavMeshAgent agent;
    public Rigidbody rb;
    public float camHeight = 56f;
    public Transform roll;
    public AudioClip au;

    [SerializeField]
    private int camState = 0;

    Animator anim;

    [Header("Lightning")] public Light flashLight;
    public bool flashLightOn = false;
    public float flashLightOnTime = 10f;

    public bool isrunning = false;
    public float speed = 5f;
    private Vector3 previousforward= new Vector3(0, 0, 0);

    public LayerMask _layerMask;
    GameObject spawnedClicker;

    public GameObject Clicker;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update ()
    {
        
        UpdateCam();
        UpdateFlashLight();
        UpdateSpeed();
        float v_move = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float h_move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector3 movement = new Vector3(h_move, 0, v_move);

        if (h_move != 0 || v_move != 0)
        {
            
            rb.transform.forward = movement;
        }
        else
        {
            
        }
        //Debug.Log(GetComponent<Rigidbody>().velocity.magnitude);
        rb.MovePosition(rb.position + movement);
        //Debug.Log(Input.GetMouseButtonDown(1));
        
    }



    bool V3Equals(Vector3 a, Vector3 b)
    {
        return Vector3.SqrMagnitude(a - b) <= 1;
    }


    private void UpdateCam()
    {
        Vector3 camNewPosition;
        Vector3 camNewRotation;
        switch (camState)
        {
                
            case 1:
                if (transform.rotation.eulerAngles.y>0&&transform.rotation.eulerAngles.y<180)
                {
                    camNewPosition = transform.position+ Vector3.up * camHeight - Vector3.right * 20;
                    camNewRotation = new Vector3(125,-90,-180);

                }
                else
                {
                    camNewPosition = transform.position+ Vector3.up * camHeight + Vector3.right * 25;
                    camNewRotation = new Vector3(45,-90,0);
                }

                break;
            case 2:
                
                if (transform.rotation.eulerAngles.y>90&&transform.rotation.eulerAngles.y<270)
                {
                    camNewPosition = transform.position + Vector3.up * camHeight + Vector3.forward * 25;
                    camNewRotation = new Vector3(125,0,180);
                }
                else
                {
                    camNewPosition = transform.position+ Vector3.up * camHeight - Vector3.forward * 14;
                    camNewRotation = new Vector3(65,0,0);
                }
                break;
                
            case 0:
            default:
                camNewPosition = transform.position + Vector3.up * camHeight;
                camNewRotation = new Vector3(90,0,0);
                break;
           
        }
        
        cam.transform.position = Vector3.Lerp(cam.transform.position, camNewPosition,
            camPositionLerpSpeed*Time.deltaTime);
        cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, Quaternion.Euler( camNewRotation), 
            camRotationLerpSpeed*Time.deltaTime);
    }


    private void UpdateFlashLight()
    {
        if (Input.GetMouseButtonDown(1))
            if (!flashLightOn)
            {
                flashLight.enabled = true;
                flashLightOn = true;
                StartCoroutine("ChargeFlashLight");
            }
            else
            {
                flashLight.enabled = false;
                flashLightOn = false;
            }
    }

    private void UpdateSpeed()
    {
        if (Input.GetKey(KeyCode.Space) && !isrunning)
        {
            isrunning = true;
            speed = 9f;
            StartCoroutine("Running");
        }
    }

    IEnumerator Running()
    {
        yield return new WaitForSeconds(3);
        speed = 5f;
        isrunning = false;
    }

    IEnumerator ChargeFlashLight()
    {
        yield return new WaitForSeconds(flashLightOnTime);
        flashLight.enabled = false;
        flashLightOn = false;

    }

}
