using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    private new MeshRenderer renderer;
    private Rigidbody gravity;
    [SerializeField] private float timeToWait = 3f;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        gravity = GetComponent<Rigidbody>();
        
        renderer.enabled = false;
        gravity.useGravity = false;
    }

    private void Update()
    {
        if (Time.time > timeToWait)
        {
            renderer.enabled = true;
            gravity.useGravity = true;
        }
    }
}
