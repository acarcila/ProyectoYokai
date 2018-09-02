using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCamara : MonoBehaviour {

	public GameObject objetivo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 posicionObjetivo = new Vector3 (objetivo.transform.position.x, objetivo.transform.position.y, transform.position.z);
		transform.position = Vector3.MoveTowards (transform.position, posicionObjetivo, Time.deltaTime * 20f);
//		transform.position = new Vector3 (objetivo.transform.position.x, objetivo.transform.position.y, transform.position.z);
	}
}
