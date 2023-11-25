using UnityEngine;

public class InstantiateObjects : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToInstantiate;  // The prefab to instantiate

    [SerializeField]
    private float instantiationRange = 5f;   // The range within which objects will be instantiated

    [SerializeField]
    private Transform spawnPoint;  // The point where objects will be spawned

    [SerializeField]
    private Vector3 objectSpawnOffset = Vector3.zero;  // The offset to adjust the spawned object's position

    void Start()
    {
        // Start the instantiation process, calling the SpawnObject method every 5 seconds, with an initial delay of 0 seconds.
        InvokeRepeating("SpawnObject", 5f, 5f);
    }

    void SpawnObject()
    {
        // Generate a random position within the specified range
        Vector3 randomPosition = new Vector3(Random.Range(-instantiationRange, instantiationRange),
            0f,
            Random.Range(-instantiationRange, instantiationRange));

        // Calculate the final spawn position by adding the offset to the spawn point
        Vector3 finalSpawnPosition = spawnPoint.position + objectSpawnOffset + randomPosition;

        // Instantiate the object at the final spawn position
        Instantiate(objectToInstantiate, finalSpawnPosition, Quaternion.identity);
    }
}