using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CameraMovement : MonoBehaviour {

	Rigidbody2D rb;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D>();
	}

	public void SetSpeed(Vector2 speed) {
		//print(speed);
		//print(rb);
		rb.velocity = speed;
	}
}
