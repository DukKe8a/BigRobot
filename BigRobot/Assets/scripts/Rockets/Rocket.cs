using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Robot"))
        {
            HealthManager.instance.TakeDamage(15f);
            Destroy(gameObject);
        }
        if (other.CompareTag("Shield"))
        {
            Destroy(gameObject);
        }
    }
}