using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorMovimentacao : MonoBehaviour {

	public float velocidade; 

	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward  * velocidade * Time.deltaTime);		
	}
}
