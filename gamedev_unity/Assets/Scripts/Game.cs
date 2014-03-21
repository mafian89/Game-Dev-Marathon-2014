using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	public static Game Instance = null;

	public GameObject tileTemplate;
	public Camera mainCamera;

	private GameObject[,] m_tiles;

	private const int ROWS = 7;
	private const int COLS = 5;

	void Awake() {
		Instance = this;
	}	

	GameObject createTile(int row, int col) {
		GameObject tile = Instantiate(tileTemplate,
		                              new Vector3(col * 96f / Screen.width, -row * 96f / Screen.width, 0.05f),
		                              Quaternion.identity) as GameObject;

		tile.transform.localScale = new Vector3(96f / Screen.width, 96f / Screen.width);
		tile.SetActive(true);
		tile.renderer.enabled = true;
		tile.collider2D.enabled = true;

		Tile tileBehaviour = tile.GetComponent<Tile>();

		//tileBehaviour.addNeighbourTile(m_tiles[col - 1, row - 1]);

		m_tiles[col, row] = tile;
	}



	void generateTiles() {
		m_tiles = new GameObject[COLS, ROWS];
		for (int col = 0; col < COLS; col++) {
			for (int row = 0; row < ROWS; row++) {
				createTile(row, col);
			}
		}
	}

	// Use this for initialization
	void Start () {
		Screen.SetResolution(480, 800, false);
		mainCamera.rect = new Rect(0, 0, 1, 1);
		generateTiles();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
