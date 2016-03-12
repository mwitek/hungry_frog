using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {
	private bool gameStarted = false;

	[SerializeField]
	private Text gameStateText;

	[SerializeField]
	private GameObject player;

	[SerializeField]
	private BirdMovement birdMovement;

	[SerializeField]
	private FollowCamera followCamera;

	//These are for a timer
	private float restartDelay = 3f;
	private float restartTimer;

	private PlayerMovement playerMovement;
	private PlayerHealth playerHealth;
	// Use this for initialization
	void Start () {
		// hide mouse cursor
		Cursor.visible = false;

		// Get Player Components
		playerMovement = player.GetComponent<PlayerMovement> ();
		playerHealth = player.GetComponent<PlayerHealth> ();

		// Prevent the player from moving at start
		playerMovement.enabled = false;

		// Prevent bird from moving
		birdMovement.enabled = false;

		// Prevent camera from moving
		followCamera.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if ( (gameStarted == false) && (Input.GetKeyUp (KeyCode.Space)) ) {
			StartGame();
		}

		// If player is dead, end game
		if (playerHealth.alive == false) {
			EndGame();

			// Restart the game with a timer
			// When timer exceeds the delay we reload the level using the current level
			restartTimer = restartTimer + Time.deltaTime;

			if (restartTimer >= restartDelay) {
				Scene scene = SceneManager.GetActiveScene(); 
				SceneManager.LoadScene(scene.name);

			}


		}
	}

	private void StartGame() {
		// Set game state
		gameStarted = true;

		// shady way to 'remove' start text
		gameStateText.color = Color.clear;

		// Allow player to move
		playerMovement.enabled = true;

		// Allow bird to move
		birdMovement.enabled = true;

		// Allow the camera to move
		followCamera.enabled = true;

	}

	private void EndGame() {
		// Set game state
		gameStarted = false;

		//show game state text and change to game over message
		gameStateText.text = "Game Over!";
		gameStateText.color = Color.white;

		//completely disable and remove the player game object
		player.SetActive(false);
	}
}
