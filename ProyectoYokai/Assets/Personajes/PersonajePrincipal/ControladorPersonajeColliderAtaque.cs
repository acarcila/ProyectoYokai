using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorPersonajeColliderAtaque : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{	
		if(other.gameObject.tag == "enemigo")
		{
			StartCoroutine(reiniciarEscena());
			other.GetComponent<ControladorEnemigoVida>().reducirVida(1);
		}
	}

	private IEnumerator reiniciarEscena()
	{
		yield return new WaitForSeconds(1f);
		Debug.Log("Personaje");
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
