using System.Collections;
using UnityEngine;

public class SpawnOnKeyPress : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Transform spawnPoint;
    public float lifeTime;
    private bool canSpawn = true;

    private bool playerInside = false;

    void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E) && canSpawn)
        {
            StartCoroutine(SpawnRoutine());
        }
    }

    IEnumerator SpawnRoutine()
    {   
        canSpawn = false;

        GameObject obj = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
        Destroy(obj, lifeTime);

        yield return new WaitForSeconds(lifeTime);

        canSpawn = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            playerInside = false;
        }
    }
}