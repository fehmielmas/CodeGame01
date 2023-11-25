using UnityEngine;
using UnityEngine.UI;  // UI öğelerini kullanmak için gerekli kütüphane

public class WinText : MonoBehaviour
{
    public TMPro.TextMeshProUGUI winText;

    void Start()
    {
        // Oyun başında kazanma metni devre dışı bırakılmış olarak başlar.
        if (winText != null)
        {
            winText.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // Eğer çarpışan nesnenin etiketi "Player" ise (veya başka bir koşul ekleyebilirsiniz)
        if (other.gameObject.tag == "Player")
        {
            // Oyun kazanıldığında kazanma metnini aktif hale getir.
            if (winText != null)
            {
                winText.gameObject.SetActive(true);
                winText.text = "You Win!";
            }
        }
    }
}