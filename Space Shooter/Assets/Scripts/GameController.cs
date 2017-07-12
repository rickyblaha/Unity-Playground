using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float startWait;
	public float spawnWait;
	public float waveWait;

	public Text scoreText;
	public Text gameOverText;
	public Text restartText;
	private int score;
	public int lives;

	void Start () {
		score = 0;
		gameOverText.text = "";
		restartText.text = "";
		UpdateScore ();
		StartCoroutine( SpawnWaves () );
	}

	void Update() {
		if (lives == 0) {
			if (Input.GetKeyDown (KeyCode.R)) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			}
		}
	}

	IEnumerator SpawnWaves () {
		yield return new WaitForSeconds (startWait);

		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity; // Means no rotation.

				Instantiate (hazard, spawnPosition, spawnRotation);

				yield return new WaitForSeconds (spawnWait);
			}

			yield return new WaitForSeconds (waveWait);

			if (lives == 0) {
				restartText.text = "Press 'R' to retry!";
				break;
			}
		}
	}

	public void AddScore(int newScoreValue) {
		score += newScoreValue;
		UpdateScore ();
	}

	public void PlayerDestroyed() {
		lives--;
		if (lives == 0) {
			gameOverText.text = "GAME OVER";
		}
	}

	void UpdateScore() {
		scoreText.text = "Score: " + score;
	}
}
