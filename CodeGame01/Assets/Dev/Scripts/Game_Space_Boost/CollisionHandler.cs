using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class CollisionHandler : MonoBehaviour
{
    
    [SerializeField] private AudioClip success;
    [SerializeField] private AudioClip crash;
    [FormerlySerializedAs("levelLoadEffect")] public float levelLoadDelay = 0.5f;

    [SerializeField] private ParticleSystem successParicles;
    [SerializeField] private ParticleSystem crashParticles;
    private new MeshCollider renderer;
     
    
    private AudioSource audioSource;
    private bool isTransitioning;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        renderer = GetComponent<MeshCollider>();

        renderer.enabled = true;
    }

    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning)
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

    void LoadNextLevelCheat()
    {
        if (Input.GetKey(KeyCode.L))
        {
            StartSuccessSequence();
        }
        else if (Input.GetKey(KeyCode.C))

        {
            renderer.enabled = false;
        }
    }

    private void Update()
    {
        LoadNextLevelCheat();
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
