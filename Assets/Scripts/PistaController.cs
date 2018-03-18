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

	private int ultimoIndiceGerado = 0;
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
		for (int i = 0; i < currentTiles.ToArray ().Length; i++) {
			if (i > qtdeTilesNaTela) {
				Destroy (currentTiles [i - qtdeTilesNaTela-1]);
				currentTiles.RemoveAt (i - qtdeTilesNaTela-1);
			}
		}
	}

	void GeradorTiles(int index = -1){
		GameObject gameObject = Instantiate (pistaPrefabs[ProximoPrefabTile()]) as GameObject;
		gameObject.transform.SetParent (transform);
		gameObject.transform.position = Vector3.right * spawnerEmX;
		spawnerEmX += tileInicialLen;
		currentTiles.Add (gameObject);
		Debug.Log (currentTiles.ToArray ().Length);
	}

	private int ProximoPrefabTile(){
		
		if (pistaPrefabs.Length <= 1) {
			return 0;
		}

		int indiceGerado = ultimoIndiceGerado;

		while (indiceGerado == ultimoIndiceGerado) {
			indiceGerado = Random.Range (0, pistaPrefabs.Length);
			Debug.Log (indiceGerado);
		}

		ultimoIndiceGerado = indiceGerado;

		return indiceGerado;

	}
}
