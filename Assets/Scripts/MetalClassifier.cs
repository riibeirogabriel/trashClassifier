using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class MetalClassifier : MonoBehaviour
{
    private Rigidbody rb;
    public PlayerComponent player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {

        player.GetNextPlayer();
        if (other.gameObject.CompareTag("Metal"))
        {
	    Debug.Log("PARABENS VOCE ACERTOU");
        }
        else{
	    Debug.Log("Infelizmente vc errou a lixeira certa é:");
            Debug.Log(other.tag);
        }
    }

}
