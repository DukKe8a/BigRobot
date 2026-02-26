using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    public GameObject buildingPrefab;
    public float spawnZ = 100f;
    public float spawnInterval = 2f;

    public float[] lanePositions = { -20f, 0f, 20f };

    void Start()
    {
        InvokeRepeating(nameof(SpawnBuilding), 0f, spawnInterval);
    }

    void SpawnBuilding()
    {
        int randomLane = Random.Range(0, lanePositions.Length);

        Vector3 spawnPosition = new Vector3(lanePositions[randomLane], 0f, spawnZ);

        Instantiate(buildingPrefab, spawnPosition, Quaternion.identity);
    }
}