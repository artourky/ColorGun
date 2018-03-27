using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {

	Rigidbody2D rb;
	public SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(Random.Range(15f, 25f), 0f);
	}

	public void ChangeColor(Color color) {
		//print(color);
		sprite.color = color;
	}

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
