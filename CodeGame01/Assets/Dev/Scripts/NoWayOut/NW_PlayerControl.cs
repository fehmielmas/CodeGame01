using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class NW_PlayerControl : MonoBehaviour
{
    [SerializeField] private float controlSpeed = 5f;
    // Update is called once per frame
    void Update()
    {
        float xAxisThrow = Input.GetAxis("Horizontal");
        float yAxisThrow = Input.GetAxis("Vertical");

        float xOffset = xAxisThrow * Time.deltaTime * controlSpeed;
        float newXPos = transform.localPosition.x + xOffset;
        transform.localPosition = new Vector3(newXPos, transform.localPosition.y, transform.localPosition.z);
    }

}