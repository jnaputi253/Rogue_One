using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public int playerFoodPoints = 100;

	[HideInInspector]
	public bool playersTurn = true;
	public BoardManager boardScript;
	public static GameManager instance = null;
	private int level = 3;

	void Awake() {
		if(instance == null) {
			instance = this;
		} else if(instance != this){
			Destroy (instance);
		}

		DontDestroyOnLoad (gameObject);
		boardScript = GetComponent<BoardManager> ();
		InitGame ();
	}

	public void GameOver() {
		enabled = false;
	}

	void InitGame() {
		boardScript.SetupScene (level);
	}
}
