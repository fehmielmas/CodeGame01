using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("this thing is friendly");
                break;
            case "Finish":
                NextLevel();
                break;
            case "Fuel":
                Debug.Log("More Fuell yeahhh");
                break;
            case "Enemy":
                ReloadLevel();
                break;
        }
    }

    void NextLevel()
    {
        
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    
    
}
