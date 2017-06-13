using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable once CheckNamespace
public class PlayerInput : MonoBehaviour
{
	private Rigidbody _cursor;
	private AudioSource _cursorHit;
	private bool _cursorClicked = false;
	private bool _cursorReturning = false;
	private int _hitCount = 0;
	public Text HitCounterText;
	public int Speed = 10;
	public int BounceSpeed = 250;

	// Use this for initialization
	void Start()
	{
		_cursor = GetComponent<Rigidbody>();
		_cursorHit = GetComponent<AudioSource>();
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
		_cursorHit.Play();
		_hitCount++;
		HitCounterText.text = _hitCount.ToString();
		_cursorReturning = true;
		_cursorClicked = false;
	}

}
