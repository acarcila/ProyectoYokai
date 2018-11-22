using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitesBehaviour : MonoBehaviour {

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.tag == "fireBall")
		{
			Destroy(other.gameObject);
		}
	}
}
