using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorOniColliderAtaque : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{	
		if(other.gameObject.name == "Personaje")
		{
			other.GetComponent<ControladorPersonaje>().morir();
			StartCoroutine(reiniciarEscena());
		}
	}
	
	private IEnumerator reiniciarEscena()
	{
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

}
