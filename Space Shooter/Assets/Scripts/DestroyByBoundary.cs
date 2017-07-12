using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	// Called when object first stops touching another object.
	void OnTriggerExit(Collider other) {
		Destroy(other.gameObject);
	}
}
