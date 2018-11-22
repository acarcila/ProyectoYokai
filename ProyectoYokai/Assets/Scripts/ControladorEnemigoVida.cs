using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorEnemigoVida : MonoBehaviour {

	public int vida;
	public GameObject puente;

	public void reducirVida(int daño)
	{
		vida -= daño;

		if(vida <= 0)
		{
			morir();
		}
	}

    private void morir()
    {
		activarPuente();
        Destroy(this.gameObject);
    }

	public void activarPuente()
	{
		puente.SetActive(true);
	}
}
