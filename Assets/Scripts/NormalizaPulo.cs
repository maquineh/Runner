using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalizaPulo : MonoBehaviour {
	public float quedaMult = 2.5f;
	public float puloMenorMult = 3f;
	public Rigidbody rigidBody;

	void Update(){
		if (rigidBody.velocity.y < 0) {
			rigidBody.velocity  += Vector3.up * Physics.gravity.y * (quedaMult - 1) * Time.deltaTime;
		}
	}

	void Awake(){
		rigidBody = GetComponent<Rigidbody> ();	
	}
}
