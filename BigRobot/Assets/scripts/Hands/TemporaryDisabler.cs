using System.Collections;
using UnityEngine;

public class TemporaryDisabler : MonoBehaviour
{
    public float disableTime;

    private Collider col;
    private bool isDisabled = false;

    void Start()
    {
        col = GetComponent<Collider>();
    }

    public void DisableTemporarily()
    {
        if (!isDisabled)
        {
            StartCoroutine(DisableRoutine());
        }
    }

    IEnumerator DisableRoutine()
    {
        isDisabled = true;

        col.enabled = false;

        yield return new WaitForSeconds(disableTime);

        col.enabled = true;

        isDisabled = false;
    }
}