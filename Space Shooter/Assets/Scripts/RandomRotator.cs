using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

	public float tumble;

	private Rigidbody rb;

	void Start() {
		rb = GetComponent<Rigidbody> ();
	
		rb.angularVelocity = Random.insideUnitSphere * tumble;

		// ...is the simpler version of:
		//rb.angularVelocity = new Vector3 (Random.value * tumble, Random.value * tumble, Random.value * tumble);
	}
}
