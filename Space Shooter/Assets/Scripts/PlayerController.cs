using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;

	public float fireRate = 0.25f;
	private float nextFire = 0.0f;

	private Rigidbody rb;
	private AudioSource audio;

	void Start() {
		rb = GetComponent<Rigidbody> ();
		audio = GetComponent<AudioSource> ();
	}

	// Non-physics stuff to do every frame.
	void Update() {
		if (Input.GetButton("Fire1") && Time.time >= nextFire) {
			nextFire = Time.time + fireRate;
			//GameObject clone = 
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation); // as GameObject;

			audio.Play();
		}
	}

	// Physics stuff to update every frame.
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal * speed, 0, moveVertical * speed);
		rb.velocity = movement;

		rb.position = new Vector3 (
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
			0,
			Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
		);

		rb.rotation = Quaternion.Euler (0, 0, rb.velocity.x * -tilt);
	}
}
