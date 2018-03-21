using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private Vector3 vetorMovimento;
	private Vector3 distanciaMinima;
	private Transform direcaoCamera;


	private Vector3 delayAnimacao = new Vector3(0,5,5);
	private float startAnimacao = 3.0f;
	private float transicao = 0.0f;

	// Use this for initialization
	void Start () {
		direcaoCamera = GameObject.FindGameObjectWithTag ("player").transform;
		distanciaMinima = transform.position - direcaoCamera.position;
	}
	
	// Update is called once per frame
	void Update () {
		vetorMovimento = direcaoCamera.position + distanciaMinima;

		vetorMovimento.z = 0;

		vetorMovimento.y = Mathf.Clamp (vetorMovimento.y, 3, 5);

		if (transicao > 1.1f) {
			//Animacao do game normal
			transform.position = vetorMovimento;
		} else {
			transform.position = Vector3.Lerp (vetorMovimento + delayAnimacao, 
				vetorMovimento, transicao);
			transicao = transicao + Time.deltaTime * 1 / startAnimacao;
			//transform.LookAt (direcaoCamera.position + new Vector3(0,3,0));
			transform.LookAt (direcaoCamera.position + Vector3.up);
		}

	}
}
