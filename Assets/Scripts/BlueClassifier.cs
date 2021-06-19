using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class BlueClassifier : MonoBehaviour
{
    //private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Paper"))
        {
            Debug.Log("Classificou corretamente");
        }
        else
        {
            Debug.Log("Classificou incorretamente");

        }
    }

}
