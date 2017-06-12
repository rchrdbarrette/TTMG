using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ReSharper disable once CheckNamespace
public class PlayerInput : MonoBehaviour
{
	private Rigidbody _cursor;
	private bool _cursorClicked = false;
	private bool _cursorReturning = false;
	public int Speed = 10;
	public int BounceSpeed = 250;

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
			_cursorClicked = true;
		}
	}

	// FixedUpdate is called after all objects are loaded and once per frame
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 position = _cursor.transform.position;

		position.x += moveHorizontal * Speed * Time.deltaTime;
		position.y += moveVertical * Speed * Time.deltaTime;

		// move the cursor around by keyboard or controller
		if (_cursorClicked)
		{
			position.z += 0.1f * BounceSpeed * Time.deltaTime;
			_cursor.transform.position = position;
		}
		else if (_cursorReturning)
		{
			position.z += -0.1f * BounceSpeed * Time.deltaTime;
			_cursor.transform.position = position;

			if (!(position.z <= -5f)) return;

			_cursorReturning = false;
			position.z = -5f;
		}
		else
		{
			_cursor.transform.position = position;
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log("OnCollisionEnter called...");
		_cursorReturning = true;
		_cursorClicked = false;
	}

}
