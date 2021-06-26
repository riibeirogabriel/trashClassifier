using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GlassClassifier : MonoBehaviour
{
    public GameObject somePrefab;
    private GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Ball");
        ball.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Glass"))
        {
            ball.SetActive(true);
            other.gameObject.SetActive(false);

            Debug.Log("Glass +1");
        }
        else{
            Debug.Log(other.tag);
        }
    }

}
