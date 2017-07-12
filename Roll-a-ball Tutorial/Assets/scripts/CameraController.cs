using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}

	// Called after Update (once per frame) so player is guaranteed to have moved.
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
