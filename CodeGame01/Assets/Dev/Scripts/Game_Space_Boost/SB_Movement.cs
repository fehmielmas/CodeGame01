using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Debug = UnityEngine.Debug;

public class SB_Movement : MonoBehaviour
{
    private Rigidbody rb; 
    [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private float mainThrust = 200f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.freezeRotation = true;
            rb.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust);
            rb.freezeRotation = false;
        }
        
    }

    void ProcessRotation()
    {
        if (Input.GetKey((KeyCode.A)))
        {
            ApplyRotation(rotateSpeed);
        }
        else if (Input.GetKey((KeyCode.D)))
        {
            ApplyRotation(-rotateSpeed);
        }
    }

    public void ApplyRotation(float rotationThisFrame)
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
    }
}
