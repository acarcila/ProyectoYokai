using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDemon : MonoBehaviour
{

    public float velocidad;
    public GameObject personaje;
    public GameObject fireBallPrefab;
    public float tiempoMaximoCooldownAtaque;
    public float tiempoMaximoCooldownDescanso;
    public float tiempoMaximoDescanso;
    public Animator animOniMovimiento;

    public enum Estados { caminando, descansando };

    private Estados estado;
    private float tiempoCooldownAtaque;
    private float tiempoCooldownDescanso;
    private float tiempoDescanso;
    private bool atacando;
    private Vector3 direccionEmbestida;

    // Use this for initialization
    void Start()
    {
        estado = Estados.caminando;

        tiempoCooldownAtaque = tiempoMaximoCooldownAtaque;

        tiempoCooldownDescanso = tiempoMaximoCooldownDescanso;
        tiempoDescanso = tiempoMaximoDescanso;

        atacando = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (estado == Estados.caminando)
        {
            girar();

            if (Vector3.Distance(this.transform.position, personaje.transform.position) >= 2f)
            {
                transform.position = Vector3.MoveTowards(transform.position, personaje.transform.position, velocidad * Time.deltaTime);

                // Quaternion rotation = Quaternion.LookRotation(personaje.transform.position - transform.position, transform.TransformDirection(Vector3.up));
                // transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
            }

            if (tiempoCooldownAtaque > 0)
            {
                tiempoCooldownAtaque -= Time.deltaTime;
            }
            else
            {
                disparar();
                tiempoCooldownAtaque = tiempoMaximoCooldownAtaque;
            }

        }

        if (estado == Estados.descansando)
        {
            if (tiempoDescanso > 0)
            {
                tiempoDescanso -= Time.deltaTime;
            }

            if (tiempoDescanso <= 0)
            {
                estado = Estados.caminando;
                tiempoDescanso = tiempoMaximoDescanso;
            }
        }
        else
        {
            if (tiempoCooldownDescanso > 0)
            {
                tiempoCooldownDescanso -= Time.deltaTime;
            }
            else
            {
                estado = Estados.descansando;
                tiempoCooldownDescanso = tiempoMaximoCooldownDescanso;
            }
        }
    }

    public string getEstado()
    {
        return estado.ToString();
    }

    public void girar()
    {
        Vector3 vectorDiferencia = transform.position - personaje.transform.position;
        float diferenciaX = vectorDiferencia.x;
        float diferenciaY = vectorDiferencia.y;
        animOniMovimiento.SetBool("IsRunning", true);
        animOniMovimiento.SetFloat("AxisX", diferenciaX);
        animOniMovimiento.SetFloat("AxisY", diferenciaY);

        if ((Mathf.Abs(diferenciaX) - Mathf.Abs(diferenciaY)) > 0)
        {
            if (diferenciaX > 0)
            {
                this.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

    public void disparar()
    {
        fireBallPrefab.GetComponent<FireBallBehaviour>().velocidad = 10;

        fireBallPrefab.GetComponent<FireBallBehaviour>().direccion = new Vector2(0, 1);
        Instantiate(fireBallPrefab, this.transform.position, fireBallPrefab.transform.rotation);

        fireBallPrefab.GetComponent<FireBallBehaviour>().direccion = new Vector2(1, 1);
        Instantiate(fireBallPrefab, this.transform.position, fireBallPrefab.transform.rotation);

        fireBallPrefab.GetComponent<FireBallBehaviour>().direccion = new Vector2(1, 0);
        Instantiate(fireBallPrefab, this.transform.position, fireBallPrefab.transform.rotation);

        fireBallPrefab.GetComponent<FireBallBehaviour>().direccion = new Vector2(1, -1);
        Instantiate(fireBallPrefab, this.transform.position, fireBallPrefab.transform.rotation);

        fireBallPrefab.GetComponent<FireBallBehaviour>().direccion = new Vector2(0, -1);
        Instantiate(fireBallPrefab, this.transform.position, fireBallPrefab.transform.rotation);

        fireBallPrefab.GetComponent<FireBallBehaviour>().direccion = new Vector2(-1, -1);
        Instantiate(fireBallPrefab, this.transform.position, fireBallPrefab.transform.rotation);

        fireBallPrefab.GetComponent<FireBallBehaviour>().direccion = new Vector2(-1, 0);
        Instantiate(fireBallPrefab, this.transform.position, fireBallPrefab.transform.rotation);

        fireBallPrefab.GetComponent<FireBallBehaviour>().direccion = new Vector2(-1, 1);
        Instantiate(fireBallPrefab, this.transform.position, fireBallPrefab.transform.rotation);
    }

    void OnCollisionEnter2D(Collision2D other)
    {

    }
}
