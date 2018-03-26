using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour {

	public Bullet bullet;

	public GameObject[] colors;

	public Vector2 moveSpeed = new Vector2(10f, 0f);
	public Vector2 jumpForce = new Vector2(0f, 5f);

	Rigidbody2D rb;
	Color colorChosen;

	bool amIDead;

	bool canFirstJump;
	//bool canSecondJump;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = moveSpeed;
		colorChosen = Color.red;
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
		var tempBullet = Instantiate(bullet, transform);
		bullet.sprite.color = colorChosen;
	}

	public void PickColor(int color) {
		switch (color)
		{
			case 0:
				colors[0].transform.GetChild(0).gameObject.SetActive(true);
				colors[1].transform.GetChild(0).gameObject.SetActive(false);
				colors[2].transform.GetChild(0).gameObject.SetActive(false);
				colors[3].transform.GetChild(0).gameObject.SetActive(false);
				colorChosen = Color.red;
				break;
			case 1:
				colors[1].transform.GetChild(0).gameObject.SetActive(true);
				colors[0].transform.GetChild(0).gameObject.SetActive(false);
				colors[2].transform.GetChild(0).gameObject.SetActive(false);
				colors[3].transform.GetChild(0).gameObject.SetActive(false);
				colorChosen = Color.green;
				break;
			case 2:
				colors[2].transform.GetChild(0).gameObject.SetActive(true);
				colors[1].transform.GetChild(0).gameObject.SetActive(false);
				colors[0].transform.GetChild(0).gameObject.SetActive(false);
				colors[3].transform.GetChild(0).gameObject.SetActive(false);
				colorChosen = Color.blue;
				break;
			case 3:
				colors[3].transform.GetChild(0).gameObject.SetActive(true);
				colors[1].transform.GetChild(0).gameObject.SetActive(false);
				colors[2].transform.GetChild(0).gameObject.SetActive(false);
				colors[0].transform.GetChild(0).gameObject.SetActive(false);
				colorChosen = Color.yellow;
				break;
		}
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
