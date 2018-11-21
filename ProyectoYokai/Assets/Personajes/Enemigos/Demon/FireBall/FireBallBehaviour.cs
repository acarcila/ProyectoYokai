using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireBallBehaviour : MonoBehaviour
{

    public float velocidad;
    public Vector2 direccion;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.GetComponent<Rigidbody2D>().velocity = direccion * velocidad;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Personaje")
        {
            StartCoroutine(reiniciarEscena());
            other.GetComponent<ControladorPersonaje>().morir();
        }

		if(other.gameObject.tag != "enemigo" && other.gameObject.tag != "fireBall")
		{
			Destroy(this.gameObject);
		}
    }

	private IEnumerator reiniciarEscena()
	{
		yield return new WaitForSeconds(1f);
		Debug.Log("oni");
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
