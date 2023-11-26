using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using Debug = UnityEngine.Debug;

public class SB_Movement : MonoBehaviour
{
    
    [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private float mainThrust = 200f;
    [SerializeField] private AudioClip mainEngine;
   
    [SerializeField] private ParticleSystem rocketFireMainFire;
    [SerializeField] private ParticleSystem rocketFireLeftFire;
    [SerializeField] private ParticleSystem rocketFireRightFire;
    
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
            rb.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust);
            rb.freezeRotation = false;
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }

            if (!rocketFireMainFire.isPlaying)
            {
                rocketFireMainFire.Play();
            } 
        }
        else
        {
            audioSource.Stop();
            rocketFireMainFire.Stop();
        }
        
    }

    void ProcessRotation()
    {
        if (Input.GetKey((KeyCode.A)))
        {
            ApplyRotation(rotateSpeed);
            if (!rocketFireRightFire.isPlaying)
            {
                rocketFireRightFire.Play();
            }
        }
        else if (Input.GetKey((KeyCode.D)))
        {
            ApplyRotation(-rotateSpeed);
            if (!rocketFireLeftFire.isPlaying)
            {
                rocketFireLeftFire.Play();
            }
        }
        else
        {
            rocketFireRightFire.Stop();
            rocketFireLeftFire.Stop();
        }
    }

    public void ApplyRotation(float rotationThisFrame)
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
    }
    
}
