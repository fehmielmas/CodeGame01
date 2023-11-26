using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class CollisionHandler : MonoBehaviour
{
    
    [SerializeField] private AudioClip success;
    [SerializeField] private AudioClip crash;
    public float levelLoadDelay = 0.5f;

    [SerializeField] private ParticleSystem successParicles;
    [SerializeField] private ParticleSystem crashParticles;
     
    
    private AudioSource audioSource;
    private bool isTransitioning;
    private bool collisionDisabled;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            StartSuccessSequence();
        }
        else if (Input.GetKey(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning || collisionDisabled )
        {
            return;
        }
            
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Use Space and  A' D' ");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            case "Enemy":
                StartCrashSequence();
                break;
        }
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        successParicles.Play();
        audioSource.PlayOneShot(success);
        GetComponent<SB_Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        crashParticles.Play();
        audioSource.PlayOneShot(crash);
        GetComponent<SB_Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    
    
}
