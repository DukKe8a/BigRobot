using System.Collections;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
    public GameObject rocketPrefab;

    public float spawnRadius;

    public float minSpawnTime;
    public float maxSpawnTime;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnRocket();

            float randomTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(randomTime);
        }
    }

    void SpawnRocket()
    {
        Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;

        Vector3 spawnPosition = new Vector3(transform.position.x + randomCircle.x, transform.position.y + randomCircle.y, transform.position.z);

        Instantiate(rocketPrefab, spawnPosition, transform.rotation);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}