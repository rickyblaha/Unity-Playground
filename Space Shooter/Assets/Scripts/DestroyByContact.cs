using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public int scoreValue;
	public GameObject explosion;
	public GameObject playerExplosion;
	private GameController gameController;

	void Start() {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		} else {
			Debug.Log ("Cannot find 'GameController' script.");
		}
	}

	// Called when collider first touches another collider.
	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Boundary")) return;

		Destroy(other.gameObject);
		Destroy(gameObject);

		Instantiate (explosion, transform.position, transform.rotation);

		if (other.CompareTag ("Player")) {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.PlayerDestroyed();
		} else {
			gameController.AddScore(scoreValue);
		}

	}
}
