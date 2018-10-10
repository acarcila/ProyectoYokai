using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorOniColliderAtaque : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{	
		if(other.gameObject.name == "Personaje")
		{
			other.GetComponent<ControladorPersonaje>().morir();
		}
	}

}
