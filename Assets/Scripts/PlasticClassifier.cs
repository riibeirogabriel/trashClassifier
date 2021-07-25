using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlasticClassifier : MonoBehaviour
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


        if (other.gameObject.CompareTag("Plastic"))
        {
       		player.GetNextPlayer(true);
    		Debug.Log("PARABENS VOCE ACERTOU");
        }
        else{
       		player.GetNextPlayer(false);
    		Debug.Log("Infelizmente vc errou a lixeira certa é:");
		Debug.Log(other.tag);
        }
    }

}
