using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class GreenClassifier : MonoBehaviour
{
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log(other);
        if (other.gameObject.CompareTag("Glass"))
        {
            Debug.Log("Classificou corretamente");
        }
        else
        {
            Debug.Log("Classificou incorretamente");

        }
    }

}
