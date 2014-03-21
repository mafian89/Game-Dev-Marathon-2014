using UnityEngine;
using System.Collections;
using System;

public class Game : MonoBehaviour {
	public static Game Instance = null;

	public GameObject tileTemplate;
	public Camera mainCamera;

	private GameObject[,] m_tiles;

	private const int ROWS = 7;
	private const int COLS = 5;



	private MonoBehaviour m_currentScene;

	void Awake() {
		Instance = this;
		DontDestroyOnLoad(this);
		Screen.SetResolution(480, 800, false);
		mainCamera.rect = new Rect(0, 0, 1, 1);
		generateTiles();
	}	

	void createTile(int row, int col) {
		GameObject tile = Instantiate(tileTemplate,
		                              new Vector3(col * 96f / Screen.width, -row * 96f / Screen.width, 0.05f),
		                              Quaternion.identity) as GameObject;

		tile.transform.localScale = new Vector3(96f / Screen.width, 96f / Screen.width);
		tile.SetActive(true);
		tile.renderer.enabled = true;
		tile.collider2D.enabled = true;
				                 
		m_tiles[col, row] = tile;
		DontDestroyOnLoad(tile);
	}

	void setupNeighbourTiles() {
		for (int row = 0; row < ROWS; row++) {
			for (int col = 0; col < COLS; col++) {
				Tile tileBehaviour = m_tiles[col, row].GetComponent<Tile>();

				// top and bottom neighbours
				if (row > 0) 
					tileBehaviour.addNeighbourTile(m_tiles[col, row - 1]);
				if (row < (ROWS - 1))
					tileBehaviour.addNeighbourTile(m_tiles[col, row + 1]);

				// left and right neighbours
				if (col < (COLS - 1))
					tileBehaviour.addNeighbourTile(m_tiles[col + 1, row]);
				if (col > 0) 
					tileBehaviour.addNeighbourTile(m_tiles[col - 1, row]);
			}
		}
	}



	void generateTiles() {
		m_tiles = new GameObject[COLS, ROWS];
		for (int col = 0; col < COLS; col++) {
			for (int row = 0; row < ROWS; row++) {
				createTile(row, col);
			}
		}
		setupNeighbourTiles();
		m_tiles[0, 0].GetComponent<Tile>().uncovered = true;
	}

	// Use this for initialization
	void Start () {

	}

	private bool m_shouldResume;
	
	// Update is called once per frame
	void Update () {
		if (m_shouldResume) {
			Destroy(m_currentScene);
			m_shouldResume = false;
		}
	}

	public void resumeGame() {
		m_shouldResume = true;
	}

	public void changeScene(string sceneName) {
		Application.LoadLevelAdditive(sceneName);
		m_currentScene = gameObject.GetComponent(sceneName) as MonoBehaviour;
	}
}
