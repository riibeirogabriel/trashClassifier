using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GlassClassifier : MonoBehaviour
{

    public PlayerComponent player;
    // Start is called before the first frame update
    void Start()
    {
	//this.player = new PlayerComponent();

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Glass"))
        {
	        player.GetNextPlayer(true);
            //other.gameObject.SetActive(false);
	    		Debug.Log("PARABENS VOCE ACERTOU");
        }
        else{
	        player.GetNextPlayer(false);
	    		Debug.Log("Infelizmente vc errou a lixeira certa é:");
          Debug.Log(other.tag);
        }
    }

}
