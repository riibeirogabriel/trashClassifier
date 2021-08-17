using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GlassClassifier : MonoBehaviour
{

    public PlayerComponent player;

    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Glass"))
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
