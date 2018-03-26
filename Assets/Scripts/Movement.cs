using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour {

	public Bullet bullet;

	public Vector2 moveSpeed = new Vector2(10f, 0f);
	public Vector2 jumpForce = new Vector2(0f, 5f);

	Rigidbody2D rb;

	bool amIDead;

	bool canFirstJump;
	//bool canSecondJump;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = moveSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.X))
		{
			Jump();
		}

		if (Input.GetKeyDown(KeyCode.C))
		{
			Shoot();
		}
	}

	void Jump() {
		if (canFirstJump)
		{
			print("[Move] Jump");
			rb.velocity += jumpForce;
			canFirstJump = !canFirstJump;
		}
	}

	void Shoot() {
		Instantiate(bullet, transform);
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Floor"))
		{
			canFirstJump = true;
		}

		if (collision.gameObject.CompareTag("Dead"))
		{
			amIDead = true;
			print("DIE");
		}
	}
}
