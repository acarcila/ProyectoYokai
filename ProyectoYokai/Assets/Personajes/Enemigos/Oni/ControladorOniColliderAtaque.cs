using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorOniColliderAtaque : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{	
		if(other.gameObject.name == "Personaje")
		{
			StartCoroutine(reiniciarEscena());
			other.GetComponent<ControladorPersonaje>().morir();
		}
	}
	
	private IEnumerator reiniciarEscena()
	{
		yield return new WaitForSeconds(1f);
		Debug.Log("oni");
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

}
