using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed;
    public float destroyZ;

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        if (transform.position.z <= destroyZ)
        {
            Destroy(gameObject);
        }
    }
}