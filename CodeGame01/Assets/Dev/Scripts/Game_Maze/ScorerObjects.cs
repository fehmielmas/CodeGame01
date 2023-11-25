using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorerObjects : MonoBehaviour
{
    public int hits = 0;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Hit")
        {
            hits++;
        }

        if (other.gameObject.tag == "Player") ;
    }
}
