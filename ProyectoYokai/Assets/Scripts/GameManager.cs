using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject oni;
	public GameObject personaje;
	private ControladorOni controladorOni;

	// Use this for initialization
	void Start () {
		controladorOni = oni.GetComponent<ControladorOni>();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
