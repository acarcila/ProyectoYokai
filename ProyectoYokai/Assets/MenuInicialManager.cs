using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuInicialManager : MonoBehaviour {

    [Header("UI")]
    public Button play;
    public Button exit;
    public musicManager musicManager;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void IniciarJuego()
    {
        SceneManager.LoadScene("MecanicasPrimitivas");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
