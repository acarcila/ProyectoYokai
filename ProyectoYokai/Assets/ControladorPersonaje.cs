using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPersonaje : MonoBehaviour {

	public float velocidad;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void FixedUpdate () {
		float movimientoHorizontal = Input.GetAxis ("Horizontal");
		float movimientoVertical = Input.GetAxis ("Vertical");

		Debug.Log (movimientoHorizontal + ", " + movimientoVertical);
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (movimientoHorizontal * velocidad * Time.deltaTime, movimientoVertical * velocidad * Time.deltaTime);
	}
}
