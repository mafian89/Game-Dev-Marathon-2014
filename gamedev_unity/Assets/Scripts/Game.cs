using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	
	public GameObject tileTemplate;
	public Camera mainCamera;

	private GameObject[,] m_tiles;

	private const int ROWS = 4;
	private const int COLS = 5;

	void generateTiles() {
		m_tiles = new GameObject[ROWS, COLS];
		for (int row = 0; row < ROWS; row++) {
			for (int col = 0; col < COLS; col++) {
				m_tiles[row, col] = Instantiate(tileTemplate, new Vector3(row * 96, -col * 96, 0), Quaternion.identity) as GameObject;
				m_tiles[row, col].SetActive(true);
				print ("Position.x=" + m_tiles[row, col].gameObject.transform.position.x
				       + ", Position.y=" + m_tiles[row, col].gameObject.transform.position.y);
			}
		}
	}

	// Use this for initialization
	void Start () {
		// DEBUG
		Screen.SetResolution(480, 800, false);
		Camera.main.orthographicSize = Screen.height / 2.0f;
		generateTiles();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
