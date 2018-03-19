using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorMovimentacao : MonoBehaviour {
	public float velocidade; 
	public Rigidbody rigidBody;
	public float velocidadePulo;

	private float velocidadeDirecionada;
	private CharacterController controller;
	private CapsuleCollider collider;

	private bool onTheGround = true;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();	
	}

	// Update is called once per frame
	void Update () {
		Debug.Log (onTheGround);
		velocidadeDirecionada = Input.GetAxisRaw ("Horizontal") * velocidade;

		/** Este código será para teste básico, devo mudar para suporte para celular **/
		if(Input.GetKeyDown(KeyCode.A)){
			rigidBody.velocity = new Vector3 (0, 0, 3) ;
		}

		if (onTheGround) {
			if(Input.GetKeyDown(KeyCode.Space)){
				onTheGround = false;
				rigidBody.velocity = new Vector3 (0, 3, 0) * velocidadePulo;
			}
		}

		if(Input.GetKeyDown(KeyCode.D)){
			rigidBody.velocity = new Vector3 (0, 0, -3);
		}

		transform.Translate (Vector3.forward  * velocidade * Time.deltaTime);	

		SumScore.Add(Mathf.RoundToInt(Time.deltaTime * 10 * velocidade));

		checaPontuacao (SumScore.Score);
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Ground") {
			onTheGround = true;
		}

		if (col.gameObject.tag == "Block") {
			Debug.Log ("GameOver");
		}

	}
		
	private void checaPontuacao(int pontos){

		if (pontos > 2000) {
			velocidade = 11;
		}

		if (pontos > 9000) {
			velocidade = 13;
		}

		if(pontos > 13000){
			velocidade = 15;
		}

		if (pontos > 18000) {
			velocidade = 17;
		}
	}
}
