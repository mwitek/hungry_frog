using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomSoundPlayer : MonoBehaviour {
	private AudioSource audioSource;

	[SerializeField]
	private List<AudioClip> soundClips = new List<AudioClip> ();

	[SerializeField]
	private float soundTimerDelay = 3f;

	private float soundTimer;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		// Increment a timer to replay sound
		soundTimer = soundTimer + Time.deltaTime;

		if ( soundTimer >= soundTimerDelay ) {
			// Reset Timer
			soundTimer = 0f;

			//Choose random sound
			AudioClip randomSound = soundClips[Random.Range(0, soundClips.Count)];

			// play the sound
			audioSource.PlayOneShot (randomSound);
		}
	}
}
