using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public bool alive;
	// Use this for initialization

	[SerializeField]
	private GameObject pickupPrefab;

	void Start () {
		alive = true;
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Enemy") && alive == true) {
			alive = false;
			Instantiate (pickupPrefab, transform.position, Quaternion.identity);
		} 
	}
}
