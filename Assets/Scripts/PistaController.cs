using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistaController : MonoBehaviour {

	public GameObject[] pistaPrefabs;

	private int indiceDeSeguranca = 4;
	private List<GameObject> currentTiles;
	private Transform playerTransf;

	private int qtdeTilesNaTela = 5;
	private float spawnerEmX = -6.0f; //Onde eu quero posicionar no eixo x o objeto
	private float tileInicialLen = 20f;

	private void Start () {
		currentTiles = new List<GameObject> ();
		playerTransf = GameObject.FindGameObjectWithTag ("player").transform;
		for (int x =0 ; x < qtdeTilesNaTela; x++){
			GeradorTiles ();
		}
	}
	
	// Update is called once per frame
	private void Update () {
		if(playerTransf.position.x > (spawnerEmX - qtdeTilesNaTela * tileInicialLen)){
			GeradorTiles ();
			LimpadorDeTiles ();
		}
		
	}

	private void LimpadorDeTiles(){
		int length = currentTiles.ToArray ().Length;
		Debug.Log (length);
		if (length > indiceDeSeguranca - 1) {
			
			Destroy (currentTiles[0]);
			currentTiles.RemoveAt (0);
		}

	}

	void GeradorTiles(int index = -1){

		GameObject gameObject = Instantiate (pistaPrefabs [0]) as GameObject;
		gameObject.transform.SetParent (transform);
		gameObject.transform.position = Vector3.right * spawnerEmX;
		spawnerEmX += tileInicialLen;
		currentTiles.Add (gameObject);
	}
}
