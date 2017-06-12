using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehavior : MonoBehaviour
{
	private Renderer _renderer;

	// Use this for initialization
	void Start ()
	{
		_renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log("Hit on Tile...");

		// lets change the color first, then animate a disappering act
		// _renderer.material.shader = Shader.Find("Albedo");
		_renderer.material.SetColor("_Color", Color.yellow);
	}
}
