using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

	[SerializeField]
	private Transform target;
	private NavMeshAgent birdAgent;
	private Animator birdAnimator;

	[SerializeField]
	private RandomSoundPlayer birdFootsteps;

	// Use this for initialization
	void Start () {
		birdAgent = GetComponent<NavMeshAgent> ();
		birdAnimator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		// set bird desitation
		birdAgent.SetDestination (target.position);

		//measure magnitude of the NavMeshAgent velocity
		float speed = birdAgent.velocity.magnitude;

		// Pass vilocity to animator
		birdAnimator.SetFloat ("Speed", speed);

		//play footsteps if bird is moving

		if (speed > 0f) {
			birdFootsteps.enabled = true;
		} else {
			birdFootsteps.enabled = false;
		}

	}
}
