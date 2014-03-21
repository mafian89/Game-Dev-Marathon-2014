using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	
	public GameObject tileTemplate;
	public Camera mainCamera;

	private GameObject[,] m_tiles;

	private const int ROWS = 7;
	private const int COLS = 5;

	void generateTiles() {
		m_tiles = new GameObject[COLS, ROWS];
		for (int col = 0; col < COLS; col++) {
			for (int row = 0; row < ROWS; row++) {
				m_tiles[col, row] = Instantiate(tileTemplate, new Vector3(col * 96f / Screen.width, -row * 96f / Screen.width, 0.05f), Quaternion.identity) as GameObject;
				m_tiles[col, row].transform.localScale = new Vector3(96f / Screen.width, 96f / Screen.width);
				m_tiles[col, row].SetActive(true);
			}
		}
	}

	// Use this for initialization
	void Start () {
		Screen.SetResolution(480, 800, false);
		mainCamera.rect = new Rect(0, 0, 1, 1);
		//Camera.main.rect = 
		generateTiles();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
