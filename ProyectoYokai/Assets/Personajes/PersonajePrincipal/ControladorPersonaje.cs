using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPersonaje : MonoBehaviour {

	public float velocidadCaminando;
    public float velocidadCorriendo;
    public float velocidadRodar;
	public float cooldownRodar;
    public GameObject colliderAtaque;
    public Animator anim;

    private float movimientoVertical;
    private float movimientoHorizontal;
    private bool rodar;
	private int frameCountRodar;
    private Vector2 posicionRodar;
    private Transform transformacion;

    // Use this for initialization
    void Start ()
    {
        rodar = false;
        transformacion = GetComponent<Rigidbody2D>().transform;
        posicionRodar = transformacion.position;

        colliderAtaque.SetActive(false);
    }

	// Update is called once per frame
	void FixedUpdate ()
    {
		movimientoHorizontal = Input.GetAxis ("Horizontal");
		movimientoVertical = Input.GetAxis ("Vertical");
        anim.SetBool("IsRunning", false);

        activarRodar(movimientoHorizontal, movimientoVertical);
		rodarPersonaje();
        if (movimientoHorizontal != 0 || movimientoVertical != 0) 
        {
            inputCorrer();
        }
        
        inputGirar();
        inputAtacar();
    }

    private void inputAtacar()
    {
        float velocidad = 0f;
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(atacar());
        }
    }

    private IEnumerator atacar()
    {
        colliderAtaque.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        colliderAtaque.SetActive(false);
    }

    private void inputCorrer()
    {
        anim.SetFloat("AxisX", movimientoHorizontal);
        anim.SetFloat("AxisY", movimientoVertical);
        float velocidad = 0f;
        if (Input.GetButton("Fire2"))
        {
            anim.SetBool("IsRunning", true);
            velocidad = velocidadCorriendo;
        }
        else
        {
            velocidad = velocidadCaminando;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(movimientoHorizontal * velocidad * Time.deltaTime, movimientoVertical * velocidad * Time.deltaTime);
    }

    private void inputGirar()
    {
        if(movimientoHorizontal > 0)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(movimientoHorizontal < 0)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        // else if(movimientoVertical > 0)
        // {
        //     this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
        // }
        // else if(movimientoVertical < 0)
        // {
        //     this.gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
        // }
    }

    private void activarRodar(float x, float y)
    {
		if (Input.GetButtonDown("Fire3") && !rodar && frameCountRodar == 0)
        {
            rodar = true;
            posicionRodar = new Vector2(posicionRodar.x + x*5f, posicionRodar.y + y*5f);
			frameCountRodar++;
        }
        else if (!rodar)
        {
            posicionRodar = transformacion.position;
        }
    }

    private void rodarPersonaje()
    {
        if (rodar)
        {
			transformacion.position = Vector2.MoveTowards(transformacion.position, posicionRodar, velocidadRodar * Time.deltaTime);
        }

        if (transformacion.position.Equals(posicionRodar))
        {
            rodar = false;
        }

		if(frameCountRodar > 0)
		{
			frameCountRodar++;
		}

		if(frameCountRodar > cooldownRodar * 60)
		{
			frameCountRodar = 0;
		}
    }

    public void morir()
    {
        Destroy(this.gameObject);
    }
}
