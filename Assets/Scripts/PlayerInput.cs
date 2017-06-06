using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	private Rigidbody cursor;
	private const float cursorSensitivity = (float) 0.01;

	// Use this for initialization
	void Start()
	{
		cursor = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Debug.Log("Mouse click at: " + Input.mousePosition);
		}
	}

	// FixedUpdate is called after all objects are loaded and once per frame
	void FixedUpdate()
	{
		// Vector3 destination = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
		Vector3 destination = Input.mousePosition;
		destination.z = -1;

		cursor.velocity = (destination - transform.position) * cursorSensitivity;
		// rigidbody.velocity = ((transform.right * mouseMovement.x) + (transform.forward * mouseMovement.y)) / Time.deltaTime;
		// cursor.velocity = ((transform.right * destination.x) + (transform.forward * destination.y)) / Time.deltaTime;
	}
}
