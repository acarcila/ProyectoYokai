using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorOni : MonoBehaviour {

	public GameObject objetivo;
	public float velocidad;
    
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        	transform.position = Vector3.MoveTowards(transform.position, objetivo.transform.position, velocidad * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("atacar");
	}
}
