using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class NW_PlayerControl : MonoBehaviour
{
    [SerializeField] private float controlSpeed = 100f;
    [SerializeField] private float xRange = 20f;
    [SerializeField] private float yRange = 20f;
    void Update()
    {
        float xAxisThrow = Input.GetAxis("Horizontal");
        float yAxisThrow = Input.GetAxis("Vertical");

        float xOffset = xAxisThrow * Time.deltaTime * controlSpeed;
        float yOffset = yAxisThrow * Time.deltaTime * controlSpeed;
        
        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;
        
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);
        
        
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

}