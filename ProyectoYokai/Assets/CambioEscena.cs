using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{	
		if(other.gameObject.name == "Personaje")
		{
			SceneManager.LoadScene("SegundoYokai", LoadSceneMode.Single);
		}
	}
}
