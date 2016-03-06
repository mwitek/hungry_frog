using UnityEngine;
using System.Collections;

public class FlyPickup : MonoBehaviour {

	[SerializeField]
	private GameObject pickupPrefab;

	void OnTriggerEnter(Collider other) {
		//if the other object intering the fly is Player, do stuff
		if (other.CompareTag ("Player")) {
			// add particle effect
			Instantiate(pickupPrefab, transform.position, Quaternion.identity);
			ScoreCounter.score++;
			FlySpawner.totalFlies--;
			Destroy (gameObject);

		}
	}
}
