using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerComponent : MonoBehaviour
{
    public float speed = 0;

    public Rigidbody rb;
    private float movementX;
    private float movementY;
    public GameObject pan;
    public GameObject wineBottle;

    // Start is called before the first frame update
    void Start()
    {
        pan.SetActive(false);
	rb = GetComponent<Rigidbody>();  
	Debug.Log(movementX);
	 
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
    
    public void GetNextPlayer(){
 	Debug.Log("Glass +1");	
	wineBottle.SetActive(false);
    	pan.SetActive(true);
	rb.velocity = Vector3.zero;
    	rb.angularVelocity = Vector3.zero; 
	rb.transform.position = new Vector3(-0.6816779f, 9.05f, -4.831217f);
    }

   
}
