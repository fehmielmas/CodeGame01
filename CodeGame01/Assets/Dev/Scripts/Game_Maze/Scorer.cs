using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    public int hits = 0;
    public TMPro.TextMeshProUGUI Score;
    
    void Start()
    {
        // Oyun başında kazanma metni devre dışı bırakılmış olarak başlar.
        if (Score != null)
        {
            Score.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Hit")
        {
            hits++;
        }
        if (other.gameObject.tag == "Player")
        {
            // Oyun kazanıldığında kazanma metnini aktif hale getir.
            if (Score != null)
            {
                Score.gameObject.SetActive(true);
                Score.text = "Hit" + hits;
            }
        }
    }
}
