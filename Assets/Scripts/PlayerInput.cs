using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	private Rigidbody _cursor;
	public int Speed = 10;

	// Use this for initialization
	void Start()
	{
		_cursor = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("space"))
		{
			Debug.Log("Fire!");
		}
	}

	// FixedUpdate is called after all objects are loaded and once per frame
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		// move the cursor around by keyboard or controller
		Vector3 position = transform.position;
		position.x += moveHorizontal * Speed * Time.deltaTime;
		position.y += moveVertical * Speed * Time.deltaTime;
		transform.position = position;
	}
}
