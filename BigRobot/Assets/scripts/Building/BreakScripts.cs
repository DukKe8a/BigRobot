using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakScripts : MonoBehaviour
{
    public Rigidbody rb;
    public bool isBroken = false;
    public int points = 10;

    void Start()
    {
        rb.isKinematic = true;
    }

    void Update()
    {
        if (isBroken)
        {
            rb.isKinematic = false;
            gameObject.tag = "Player";
            Invoke("DestroyPiece", 10f);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            isBroken = true;
            ScoreManager.instance.AddPoints(points);
        }
    }

    void DestroyPiece(){
        Destroy(this.gameObject);
    }

}
