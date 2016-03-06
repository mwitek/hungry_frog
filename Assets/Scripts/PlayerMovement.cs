using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	//all vars have to be declared first.
	private Animator playerAnimator;
	private float moveHotizontal;
	private float moveVertical;
	private Vector3 movement;
	private float turningSpeed = 20f;
	private Rigidbody playerRigidbody;

	// Use this for initialization
	void Start () {
		// Getting components and assigning it to a vars.
		// We do it in start, which only runs once.
		InitalizeComponents();
	}
	
	// Update is called once per frame
	void Update () {
		SetupGameControls();
	}

	// Updates at a fixed interval
	void FixedUpdate () {
		HandleFrogMovement();
	}

	private void SetupGameControls () {
		moveHotizontal = Input.GetAxisRaw ("Horizontal");
		moveVertical = Input.GetAxisRaw ("Vertical");
		movement = new Vector3 (moveHotizontal, 0.0f, moveVertical);
	}

	private void HandleFrogMovement () {
		if (movement != Vector3.zero) {
			Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);
			Quaternion newRotation = Quaternion.Lerp (playerRigidbody.rotation, targetRotation, turningSpeed * Time.deltaTime);
			playerRigidbody.MoveRotation (newRotation);
			playerAnimator.SetFloat ("Speed", 3f);
		} else {
			playerAnimator.SetFloat ("Speed", 0f);
		}
	}

	private void InitalizeComponents () {
		playerAnimator = GetComponent<Animator> ();
		playerRigidbody = GetComponent<Rigidbody> ();
	}
}
