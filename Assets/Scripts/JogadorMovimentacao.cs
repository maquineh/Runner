using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorMovimentacao : MonoBehaviour {

	public float velocidade; 
	public Rigidbody rigidBody;
	public float velocidadePulo;


	// Use this for initialization
	void Start () {
			
	}

	// Update is called once per frame
	void Update () {



		if(Input.GetKeyDown(KeyCode.A)){
			rigidBody.velocity = new Vector3 (0, 0, 3) * velocidadePulo ;
		}

		if(Input.GetKeyDown(KeyCode.D)){
			rigidBody.velocity = new Vector3 (0, 0, -3) * velocidadePulo;
		}

		if(Input.GetKeyDown(KeyCode.Space)){
			rigidBody.velocity = new Vector3 (0, 2, 0) * velocidadePulo;
		}

		transform.Translate (Vector3.forward  * velocidade * Time.deltaTime);		
	}
}
