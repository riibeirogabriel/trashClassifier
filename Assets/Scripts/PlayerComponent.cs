using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerComponent : MonoBehaviour
{
	public float speed = 0;

	public Rigidbody rb;
	public GameObject[] player; //["garrafa", "taça"]
	public GameObject endGame;
	public GameObject success;
	public GameObject failed;

	public TextMesh playerName; //"garrafa de vidro"
	public TextMesh scoreboard; //placar
	private float movementX;
	private float movementY;
	private int playerId=-1; //Indice do player atual
	private List<int> playerOrder; //Lista com a ordem dos players
	public System.Random random = new System.Random();
	
	void Start()
	{
		Debug.Log("Aqui");
		setAllPlayerInactive();
		rb = GetComponent<Rigidbody>();
		playerOrder = generatePlayerOrder();
		GetNextPlayer(false);

	}

	// Gera uma lista aleatória de players unicos
	public List<int> generatePlayerOrder()
	{
		var randomNumbers = Enumerable.Range(0, player.Length).OrderBy(x => random.Next()).Take(player.Length).ToList();
		return randomNumbers;
	}	

	void setAllPlayerInactive(){
		success.SetActive(false);
		failed.SetActive(false);
		for (var i = 0; i < player.Length; i++){
			player[i].SetActive(false);
		}
	}
	

	
	void OnMove(InputValue movementValue)
	{
		Vector2 movementVector = movementValue.Get<Vector2>();
		movementX = movementVector.x;
		movementY = movementVector.y;

	}

	void FixedUpdate()
	{
		Vector3 movement = new Vector3(movementX, 0.0f, movementY);
		rb.AddForce(movement * speed);
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero; 
	}
	
	void updateScoreboard(bool correct){
		if(correct){
			scoreboard.text = Convert.ToString(Convert.ToInt32(scoreboard.text) + 500);	
			failed.SetActive(false);	
			success.SetActive(true);
		}
		else if(playerId>=0){
			success.SetActive(false);	
			failed.SetActive(true);
		}
	}

	void setNextPlayer(){
		if(playerId == player.Length - 1){
			resetPosition();
			endGame.SetActive(true);
			player[playerOrder[playerId]].SetActive(false);
			speed=0;
		        //Debug.Log(endGame.Content.Header);
		}
		else{
			playerId += 1;
			player[playerOrder[playerId]].SetActive(true);
			playerName.text = player[playerOrder[playerId]].name;	
		}
		
	}
	
	void desactiveLastPlayer(){
		if(playerId>0){
			player[playerOrder[playerId-1]].SetActive(false);		
		}
	}

	void resetPosition(){
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero; 
		rb.transform.position = new Vector3(-0.6816779f, 9.05f, -4.831217f);
	}

	public void GetNextPlayer(bool correct){

		updateScoreboard(correct);
		setNextPlayer();
		desactiveLastPlayer();
		resetPosition();	
	}


}
