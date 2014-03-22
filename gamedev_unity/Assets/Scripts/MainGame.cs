using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainGame : MonoBehaviour {
	public Camera mainCamera;
	private GameObject _tileTemplate;

	void Awake() {
		_tileTemplate = Resources.Load<GameObject>("TilePrefab");
		awakeFromTileStates(Game.Instance.TileStates);
	}

	void awakeFromTileStates(List<TileState> tileStates) {
		foreach(var state in tileStates) {
			GameObject go = Instantiate(_tileTemplate,
			                            new Vector3(state.col * 0.24f, -state.row * 0.24f, 0.05f), //new Vector3(state.col * 96f / Screen.width, -state.row * 96f / Screen.width, 0.05f),
			                              Quaternion.identity) as GameObject;

			Tile tile = go.GetComponent<Tile>();
			tile.state = state;
			tile.gameObject.transform.localScale = new Vector3(0.25f, 0.25f);
			tile.gameObject.SetActive(true);
			tile.gameObject.renderer.enabled = true;
			tile.gameObject.collider2D.enabled = true;
		}
	}

	// Use this for initialization
	void Start () {
		mainCamera.rect = new Rect(0, 0, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
