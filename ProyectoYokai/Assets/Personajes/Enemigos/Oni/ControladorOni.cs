using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorOni : MonoBehaviour {

	public GameObject objetivo;
	public float velocidad;
	public GameObject personaje;
	public GameObject colliderAtaque;
	private Animator animatorColliderAtaque;
	private enum Estados {caminando, atacando, estuneado};
    private Estados estado;
	// Use this for initialization
	void Start () {
		estado = Estados.caminando;
		animatorColliderAtaque = colliderAtaque.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(estado == Estados.caminando)
		{
			if(Vector3.Distance(this.transform.position, personaje.transform.position) < 2f)
			{
				animatorColliderAtaque.SetTrigger("Atacar");
				estado = Estados.atacando;
			}
			else
			{
				transform.position = Vector3.MoveTowards(transform.position, objetivo.transform.position, velocidad * Time.deltaTime);
				Quaternion rotation = Quaternion.LookRotation(personaje.transform.position - transform.position, transform.TransformDirection(Vector3.up));
         		transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
			}

			
		}

		if(estado == Estados.atacando && !animatorColliderAtaque.GetCurrentAnimatorStateInfo(0).IsName("AnimacionAtaqueOni"))
		{
			estado = Estados.caminando;
		}
        	
	}

	void OnTriggerEnter2D(Collider2D other)
	{	
		if(other.gameObject.name == "Personaje")
		{
			
		}
	}
}
