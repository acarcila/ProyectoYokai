using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorOni : MonoBehaviour {

	public float velocidad;
	public GameObject personaje;
	public GameObject colliderAtaque;
	public GameObject colliderEmbestida;
	public float tiempoMaximoCooldownAtaque;
	public float tiempoMaximoCooldownEmbestida;
	public float velocidadEmbestida;
	public float tiempoMaximoEstuneado;
	private Animator animatorColliderAtaque;
	public enum Estados {caminando, atacando, embistiendo, estuneado};
	public enum EstadosEmbestida {canalizando, embistiendo, estuneado};
    private Estados estado;
	public EstadosEmbestida estadoEmbestida;
	private float tiempoCooldownAtaque;
	private bool atacando;
	private float tiempoCooldownEmbestida;
	private Vector3 direccionEmbestida;
	private float tiempoEstuneado;	

	// Use this for initialization
	void Start () {
		estado = Estados.caminando;
		estadoEmbestida = EstadosEmbestida.canalizando;
		animatorColliderAtaque = colliderAtaque.GetComponent<Animator>();

		tiempoCooldownAtaque = 0;
		tiempoCooldownEmbestida = tiempoMaximoCooldownEmbestida;
		tiempoEstuneado = tiempoMaximoEstuneado;

		atacando = false;
		colliderAtaque.SetActive(false);
		colliderEmbestida.SetActive(false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		bool estadoAnimacionAtaque = animatorColliderAtaque.GetCurrentAnimatorStateInfo(0).IsName("AnimacionAtaqueOni");

		if(estado == Estados.caminando)
		{
			girar();

			if(Vector3.Distance(this.transform.position, personaje.transform.position) >= 2f)
			{
				if(!estadoAnimacionAtaque && !atacando)
				{
					transform.position = Vector3.MoveTowards(transform.position, personaje.transform.position, velocidad * Time.deltaTime);
					colliderAtaque.SetActive(false);
				}
				
				
				// Quaternion rotation = Quaternion.LookRotation(personaje.transform.position - transform.position, transform.TransformDirection(Vector3.up));
         		// transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
			}
			else
			{
				estado = Estados.atacando;
			}

			
		}

		if(estado == Estados.atacando)
		{
			girar();

			if(Vector3.Distance(this.transform.position, personaje.transform.position) < 2f && tiempoCooldownAtaque <= 0)
			{
				colliderAtaque.SetActive(true);
				animatorColliderAtaque.SetTrigger("Atacar");
				atacando = true;
				tiempoCooldownAtaque = tiempoMaximoCooldownAtaque;
			}

			if(estadoAnimacionAtaque)
			{
				atacando = true;
			}
			else
			{
				atacando = false;
			}

			if(!atacando)
			{
				estado = Estados.caminando;
			}
		}

		if(estado == Estados.embistiendo)
		{
			colliderEmbestida.SetActive(true);

			if(estadoEmbestida == EstadosEmbestida.canalizando)
			{
				girar();
				StartCoroutine(canalizar());
				estadoEmbestida = EstadosEmbestida.embistiendo;
			}
			else if(estadoEmbestida == EstadosEmbestida.embistiendo)
			{
			}
			else if(estadoEmbestida == EstadosEmbestida.estuneado)
			{
				if(tiempoEstuneado > 0)
				{
					this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
					tiempoEstuneado -= Time.deltaTime;
				}
				if(tiempoEstuneado <= 0)
				{
					estado = Estados.caminando;
					estadoEmbestida = EstadosEmbestida.canalizando;
					tiempoEstuneado = tiempoMaximoEstuneado;
					tiempoCooldownEmbestida = tiempoMaximoCooldownEmbestida;
					colliderEmbestida.SetActive(false);
				}
			}
		}

		if(tiempoCooldownAtaque > 0)
		{
			tiempoCooldownAtaque -= Time.deltaTime;
		}

		if(tiempoCooldownEmbestida > 0)
		{
			tiempoCooldownEmbestida -= Time.deltaTime;
		}

		if(tiempoCooldownEmbestida <= 0)
		{
			estado = Estados.embistiendo;
		}
        	
		Debug.Log(direccionEmbestida);
	}

	public string getEstado()
	{
		return estado.ToString();
	}

	public string getEstadoEmbestida()
	{
		return estadoEmbestida.ToString();
	}

    public void girar()
    {
        Vector3 vectorDiferencia = transform.position-personaje.transform.position;
		float diferenciaX = vectorDiferencia.x;
		float diferenciaY = vectorDiferencia.y;

		if((Mathf.Abs(diferenciaX) - Mathf.Abs(diferenciaY)) > 0) 
		{
			if(diferenciaX > 0)
			{
				this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
			}
			else
			{
				this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
			}
		}
		else
		{
			if(diferenciaY > 0)
			{
				this.gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
			}
			else
			{
				this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
			}
		}
    }

	private IEnumerator canalizar()
	{
		yield return new WaitForSeconds(1f);
		direccionEmbestida = Vector3.Normalize(personaje.transform.position - transform.position);
		this.GetComponent<Rigidbody2D>().velocity = direccionEmbestida * velocidadEmbestida;
	}

	void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "estructura")
		{
			if(estado == Estados.embistiendo && estadoEmbestida == EstadosEmbestida.embistiendo)
			{
				estadoEmbestida = EstadosEmbestida.estuneado;
			}
		}
    }
}
