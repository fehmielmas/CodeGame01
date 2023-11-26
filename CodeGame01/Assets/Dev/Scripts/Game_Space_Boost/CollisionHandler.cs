using Unity.VisualScripting;
using UnityEngine;

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
                Debug.Log("You Win");
                break;
            case "Fuel":
                Debug.Log("More Fuell yeahhh");
                break;
            case "Enemy":
                Debug.Log("Crashed Something");
                break;
        }
    }
}
