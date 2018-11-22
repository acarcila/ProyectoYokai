using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorPersonajeColliderAtaque : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{	
		if(other.gameObject.tag == "enemigo")
		{
			other.GetComponent<ControladorEnemigoVida>().reducirVida(1);
		}
	}

	public void setEstadoCollider(bool estado)
	{
		this.GetComponent<BoxCollider2D>().enabled = estado;
	}

	public void setColliderFrente()
	{
		this.GetComponent<Animator>().SetInteger("DirAtaque", 0);
	}

	public void setColliderArriba()
	{
		this.GetComponent<Animator>().SetInteger("DirAtaque", 1);
	}

	public void setColliderAbajo()
	{
		this.GetComponent<Animator>().SetInteger("DirAtaque", 2);
	}
}
