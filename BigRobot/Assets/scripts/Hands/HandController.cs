using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public float rotationSpeed;
    public float rotationDuration;
    private bool rotate = false;
    public void ActivateRotation()
    {
        if (!rotate)
        {
            StartCoroutine(RotateHand());
        }
    }

    IEnumerator RotateHand()
    {
        rotate = true;
        float timer = 0f;

        while (timer < rotationDuration)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }

        timer = 0f;

        while (timer < rotationDuration)
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }

        rotate = false;
    }
}
