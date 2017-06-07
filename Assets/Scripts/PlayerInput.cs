using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	private Rigidbody _cursor;
	private const float CursorSensitivity = (float) 0.01;
	private Vector3 _cursorDelta, _mouseDelta = new Vector3(0.0f, 0.0f, 0.0f);

	// Use this for initialization
	void Start()
	{
		_cursor = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update()
	{
		//if (Input.GetButtonDown("Fire1"))
		//{
		//	Debug.Log("Mouse click at: " + Input.mousePosition);
		//}
	}

	// FixedUpdate is called after all objects are loaded and once per frame
	void FixedUpdate()
	{
		// Vector3 destination = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
		Vector3 destination = transform.position;
		_mouseDelta = (Input.mousePosition * CursorSensitivity) - _mouseDelta;
		destination = destination - _cursorDelta;
		destination.z = -1; // may be unnecessary

		if (Input.GetButtonDown("Fire1"))
		{
			var debugging = String.Format("position: {0} delta: {1} / mouse: {2} mdelta: {3}", _cursor.position, _cursorDelta, Input.mousePosition, _mouseDelta);
			Debug.Log(debugging);
		}

		// _cursor.velocity = (transform.position - _cursorDelta) * CursorSensitivity;
		_cursor.MovePosition(destination);

		// rigidbody.velocity = ((transform.right * mouseMovement.x) + (transform.forward * mouseMovement.y)) / Time.deltaTime;
		// cursor.velocity = ((transform.right * destination.x) + (transform.forward * destination.y)) / Time.deltaTime;
		// rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.eulerAngles + new Vector3(0f, rotationSpeed * Input.GetAxis("Mouse X"), 0f));
		_cursorDelta = _mouseDelta * CursorSensitivity;
	}
}
