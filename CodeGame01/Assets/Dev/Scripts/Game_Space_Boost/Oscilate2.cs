using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscilate2 : MonoBehaviour
{
    private Vector3 objectPosition;
    [SerializeField] private Vector3 objecyMovementPosition;
    [SerializeField] [Range(0,1)] private float objectMovementFactor;
    [SerializeField] private float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        objectPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period == 0) {return;}
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2f;
        float rawSinWave = Mathf.Sin(cycles * tau);

        objectMovementFactor = (rawSinWave + 1f) / 2f;
            
        Vector3 offset = objectMovementFactor * objecyMovementPosition;
        transform.position = objectPosition + offset;
    }
}
