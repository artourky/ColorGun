using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour {

	public Bullet bullet;

	public GameObject[] colors;

	public Vector2 moveSpeed = new Vector2(10f, 0f);
	public Vector2 jumpForce = new Vector2(0f, 5f);

	public CameraMovement camMove;

	Rigidbody2D rb;
	Color colorChosen;

	bool amIDead;

	bool canFirstJump;
	//bool canSecondJump;

	// Use this for initialization
	void Start () {
		//camMove = Camera.main.GetComponent<CameraMovement>();
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = moveSpeed;
		camMove.SetSpeed(moveSpeed);
		colorChosen = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.X) || Input.GetMouseButtonDown(0) && Input.mousePosition.x <= (Screen.width / 2))
		{
			Jump();
		}

		if (!EventSystem.current.IsPointerOverGameObject() && (Input.GetKeyDown(KeyCode.C) || Input.GetMouseButtonDown(0) && Input.mousePosition.x > (Screen.width / 2)))
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
		tempBullet.ChangeColor(colorChosen);
	}

	public void PickColor(int color) {
		switch (color)
		{
			case 0:
				ToggleUi(color);
				colorChosen = Color.red;
				break;
			case 1:
				ToggleUi(color);
				colorChosen = Color.green;
				break;
			case 2:
				ToggleUi(color);
				colorChosen = Color.blue;
				break;
			case 3:
				ToggleUi(color);
				colorChosen = Color.yellow;
				break;
		}
	}

	private void ToggleUi(int toCheck)
	{
		for (int i = 0; i < colors.Length; i++)
		{
			colors[i].transform.GetChild(0).gameObject.SetActive(false);
		}

		colors[toCheck].transform.GetChild(0).gameObject.SetActive(true);
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

	private void OnBecameInvisible()
	{
		print("I'm DEAD");
		//SceneManager.LoadScene(0);
	}
}
