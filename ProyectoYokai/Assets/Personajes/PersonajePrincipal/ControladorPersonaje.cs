using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPersonaje : MonoBehaviour {

	public float velocidadCaminando;
    public float velocidadCorriendo;
    public float velocidadRodar;
	public float cooldownRodar;

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
    }

	// Update is called once per frame
	void FixedUpdate ()
    {
		movimientoHorizontal = Input.GetAxis ("Horizontal");
		movimientoVertical = Input.GetAxis ("Vertical");

		activarRodar(movimientoHorizontal, movimientoVertical);
		rodarPersonaje();
        correr();
    }


    private void correr()
    {
        float velocidad = 0f;
        if (Input.GetButton("Fire2"))
        {
            velocidad = velocidadCorriendo;
        }
        else
        {
            velocidad = velocidadCaminando;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(movimientoHorizontal * velocidad * Time.deltaTime, movimientoVertical * velocidad * Time.deltaTime);
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
        Debug.Log("He morido");
    }
}
