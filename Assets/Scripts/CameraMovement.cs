using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public Transform player;

	Vector3 offset;
	Vector3 playerXZOnly;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.position;
		//offset.y = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		playerXZOnly = player.position;
		playerXZOnly.y = 0f;
		transform.position = playerXZOnly + offset;
	}
}
