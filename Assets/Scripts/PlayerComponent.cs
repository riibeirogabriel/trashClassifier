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
	public GameObject[] player;
	public TextMesh playerName;
	public TextMesh scoreboard;
	private float movementX;
	private float movementY;
	private int playerId=-1;
	private List<int> playerOrder;
	public System.Random random = new System.Random();
	
	void Start()
	{	
		setAllPlayerInactive();
		rb = GetComponent<Rigidbody>();
		playerOrder = generatePlayerOrder();
		GetNextPlayer(false);

	}
	
	public List<int> generatePlayerOrder()
	{
		var randomNumbers = Enumerable.Range(0, player.Length).OrderBy(x => random.Next()).Take(player.Length).ToList();
		return randomNumbers;
	}	

	void setAllPlayerInactive(){
		for (var i = 0; i < player.Length; i++){
			player[i].SetActive(false);
		}
	}
	
	void setNextPlayer(){
		playerId += 1;
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

	public void GetNextPlayer(bool correct){
		if(correct){
			scoreboard.text = Convert.ToString(Convert.ToInt32(scoreboard.text) + 500);		
		}
		setNextPlayer();
		player[playerOrder[playerId]].SetActive(true);
		playerName.text = player[playerOrder[playerId]].name;
		if(playerId>0){
			player[playerOrder[playerId-1]].SetActive(false);		
		}
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero; 
		rb.transform.position = new Vector3(-0.6816779f, 9.05f, -4.831217f);

	}


}
