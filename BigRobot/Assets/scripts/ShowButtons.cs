using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowButtons : MonoBehaviour
{
    public GameObject objectToEnable; // Assign the GameObject to enable in the Inspector

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the entering object has the Player tag
        {
            objectToEnable.SetActive(true); // Enable the specified GameObject
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the exiting object has the Player tag
        {
            objectToEnable.SetActive(false); // Disable the specified GameObject
        }
    }
}
