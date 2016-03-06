using UnityEngine;
using System.Collections;

public class PickupParticlesDestruction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// Destroy particle effect after it plays
		Destroy(gameObject, 2f);
	}
}
