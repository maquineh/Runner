using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorMovimentacao : MonoBehaviour {
	public float velocidade; 
	//public Rigidbody rigidBody;
	public float velocidadePulo = 10.0f;

	private float velocidadeDirecionada = 1.5f;
	private CharacterController controller;
	private CapsuleCollider collider;
	private Animator animator;
	private bool onTheGround = true;

	private float startAnimacao = 3.0f;

	private float velocidadeVertical = 0.0f;
	private float gravidade = 11.0f;

	private Vector3 vetorMovimento;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();	
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

		if(Time.time < startAnimacao){
			controller.Move (Vector3.right * 0 * Time.deltaTime);
			return;
		}

		vetorMovimento = Vector3.zero;

		bool chao = controller.isGrounded;
		Debug.Log (chao);
		if (controller.isGrounded) {
			onTheGround = true;
			if (Input.GetButton ("Jump") && onTheGround ) {
				onTheGround = false;
				velocidadeVertical = velocidadePulo;
				transform.Translate (Vector3.up * velocidadePulo * Time.deltaTime);
			}
			//velocidadeVertical = 0.0f;
		} else {
			onTheGround = false;
			velocidadeVertical -= gravidade * Time.deltaTime;
		}


		//Mover direita ou esquerda
		vetorMovimento.z = Input.GetAxisRaw("Horizontal") * (-velocidadeDirecionada);
		vetorMovimento.y = velocidadeVertical;
		vetorMovimento.x =  velocidade;
		controller.Move (vetorMovimento  * velocidade * Time.deltaTime);	

		SumScore.Add(Mathf.RoundToInt(Time.deltaTime * 10 * velocidade));

		checaPontuacao (SumScore.Score);
	}

	/*void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Ground") {
			onTheGround = true;
		}

		if (col.gameObject.tag == "Block") {
			Debug.Log ("GameOver");
		}

	}void OnCollisionExit(Collision col){
		if (col.gameObject.tag == "Ground") {
			onTheGround = false;
		}

		if (col.gameObject.tag == "Block") {
			Debug.Log ("GameOver");
		}

	}*/

	//Após pesquisar verifiquei que este evento gerencia melhor as colisões do que o OnCollisionEnter que tava meio bugado
	private void OnControllerColliderHit(ControllerColliderHit hit){
		Debug.Log ("Ponto em x: " + hit.point.x);
		Debug.Log ("Comparador:" + transform.position.x + controller.radius);
		Debug.Log (hit.point.x > transform.position.x + controller.radius);
		if (hit.point.x > transform.position.x + controller.radius) {
			GameOver ();
		}
	}

	private void GameOver(){
		Debug.Log("Faleceu");
	}

	private void checaPontuacao(int pontos){

		if (pontos > 2000) {
			velocidade = 4f;
		}

		if (pontos > 5000) {
			velocidade = 4.5f;
		}

		if(pontos > 7000){
			velocidade = 5f;
		}

		if (pontos > 10000) {
			velocidade = 5.5f;
		}

		if (pontos > 12000) {
			velocidade = 6.0f;
		}
	}
}
