using UnityEngine;
using UnityEngine.UI;  // UI öğelerini kullanmak için gerekli kütüphane

public class ScorerObjects : MonoBehaviour
{
    public TMPro.TextMeshProUGUI ScoreText;
    public int hits = 0;

    void Start()
    {
        // Oyun başında kazanma metni devre dışı bırakılmış olarak başlar.
        if (ScoreText != null)
        {
            ScoreText.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Hit")
        {
            hits++;
            Debug.Log("ScorerObjects: " + hits);
        }
        // Eğer çarpışan nesnenin etiketi "Player" ise (veya başka bir koşul ekleyebilirsiniz)
        if (other.gameObject.tag == "Hit")
        {
            // Oyun kazanıldığında kazanma metnini aktif hale getir.
            if (ScoreText != null)
            {
                ScoreText.gameObject.SetActive(true);
                ScoreText.text = "You Hit!" + hits;
            }
        }
    }
}