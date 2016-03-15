using UnityEngine;
using System.Collections;

public class FlyPickup : MonoBehaviour {

	[SerializeField]
	private GameObject pickupPrefab;
	private GameObject enemy;
	private NavMeshAgent enemyAgent;

	void Start() {
		enemy = GameObject.Find ("Bird");
		enemyAgent = enemy.GetComponent<NavMeshAgent> ();
	}

	void OnTriggerEnter(Collider other) {
		//if the other object intering the fly is Player, do stuff
		if (other.CompareTag ("Player")) {
			// add particle effect
			Instantiate(pickupPrefab, transform.position, Quaternion.identity);
			ScoreCounter.score++;
			FlySpawner.totalFlies--;
			if (ScoreCounter.score % 5 == 0) {
				enemyAgent.acceleration += 2;
				enemyAgent.speed += 2;
			}
			Destroy (gameObject);
		}
	}
}
