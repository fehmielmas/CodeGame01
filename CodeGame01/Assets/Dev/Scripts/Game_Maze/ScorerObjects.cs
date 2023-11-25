using UnityEngine;
using TMPro;

public class ScorerObjects : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public int hits = 0;

    void Start()
    {
        // Oyun başında kazanma metni devre dışı bırakılmış olarak başlar.
        if (ScoreText != null)
        {
            ScoreText.gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        // FixedUpdate içerisinde çarpışmayı sürekli kontrol et
        CheckCollision();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Hit")
        {
            hits++;
            Debug.Log("ScorerObjects: " + hits);

            // Oyun kazanıldığında kazanma metnini aktif hale getir.
            if (ScoreText != null)
            {
                ScoreText.gameObject.SetActive(true);
                ScoreText.text = "You Hit! " + hits;
            }
        }
    }

    private void CheckCollision()
    {
        // Çarpışma kontrolü ile ilgili işlemleri buraya ekleyebilirsiniz.
        // Örneğin, çarpışma sürekli kontrol edilsin ama her frame'de bir şey yapılmasın istiyorsanız, burada işlemler yapılabilir.
    }
}