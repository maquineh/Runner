using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorMovimentacao : MonoBehaviour {

	public float velocidade; 
	public Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();		
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.A)){
			rigidBody.velocity = new Vector3 (0, 2, 3);
		}

		if(Input.GetKeyDown(KeyCode.D)){
			rigidBody.velocity = new Vector3 (0, 2, -3);
		}

		if(Input.GetKeyDown(KeyCode.Space)){
			rigidBody.velocity = new Vector3 (0, 5, 0);
		}

		transform.Translate (Vector3.forward  * velocidade * Time.deltaTime);		
	}
}
