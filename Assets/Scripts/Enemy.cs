using UnityEngine;

public class Enemy : MonoBehaviour {

	public bool inAir;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		print("test");
		if (collision.gameObject.CompareTag("Bullet"))
		{
			print("Die");
		}
	}
}
