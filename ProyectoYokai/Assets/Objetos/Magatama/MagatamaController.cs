using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagatamaController : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Personaje")
        {
            GameManager gameManager = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GameManager>();
			gameManager.aumentarMagatamas(1);
            Destroy(this.gameObject);
        }
    }
}
