using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBehaviour : MonoBehaviour {

	public Image imageVida;
	public ControladorEnemigoVida controladorEnemigoVida;

	private float vidaMaxima;

	// Use this for initialization
	void Start () {
		vidaMaxima = controladorEnemigoVida.vida;
	}
	
	
	// Update is called once per frame
	void Update () {
		imageVida.fillAmount = controladorEnemigoVida.vida / vidaMaxima;
	}
}
