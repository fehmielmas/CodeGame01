using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class NW_PlayerControl : MonoBehaviour
{
    [SerializeField] private float controlSpeed = 200f;
    // Update is called once per frame
    void Update()
    {
        float xAxisThrow = Input.GetAxis("Horizontal");
        float yAxisThrow = Input.GetAxis("Vertical");

        float xOffset = xAxisThrow * Time.deltaTime * controlSpeed;
        float yOffset = yAxisThrow * Time.deltaTime * controlSpeed;
        
        float newXPos = transform.localPosition.x + xOffset;
        float newYPos = transform.localPosition.y + yOffset;
        transform.localPosition = new Vector3(newXPos, newYPos, transform.localPosition.z);
    }

}