using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public Text textCantidadMagatamas;
	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		textCantidadMagatamas.text = gameManager.cantidadMagatamas + "";
	}
}
