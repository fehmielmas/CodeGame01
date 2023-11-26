using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Debug = UnityEngine.Debug;

public class SB_Movement : MonoBehaviour
{
    
    [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private float mainThrust = 200f;
    [SerializeField] private AudioClip mainEngine;
   
    [SerializeField] private ParticleSystem rocketFire;
 
    private AudioSource audioSource; 
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    
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
            rocketFire.Play();
            rb.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust);
            rb.freezeRotation = false;
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
        }
        else
        {
            audioSource.Stop();
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
