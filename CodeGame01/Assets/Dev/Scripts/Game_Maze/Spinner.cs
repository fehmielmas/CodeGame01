using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 0.5f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,rotateSpeed,0);
    }
}
