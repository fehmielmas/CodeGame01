using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Transform originalTransform;
    [SerializeField] private float shakeDuration = 1f;
    [SerializeField] private float shakeAmount = 0.1f;
    [SerializeField] private float decreaseFactor = 1.0f;

    void Start()
    {
        originalTransform = transform;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = originalTransform.localPosition + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = originalTransform.localPosition;
        }
    }

    public void Shake()
    {
        shakeDuration = 0.5f;
    }
}