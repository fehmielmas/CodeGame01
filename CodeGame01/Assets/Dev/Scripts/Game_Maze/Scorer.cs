using UnityEngine;
using TMPro;

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

    // Scorer
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Hit")
        {
            hits++;
            Debug.Log("Scorer: " + hits);
        }
        if (other.gameObject.tag == "Player")
        {
            // Oyun kazanıldığında kazanma metnini aktif hale getir.
            if (Score != null)
            {
                Score.gameObject.SetActive(true);
                Score.text = "Hit: " + hits;
                Debug.Log("Win Text Activated: " + hits);
            }
        }
    }

}