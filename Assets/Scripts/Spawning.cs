using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour {

	public Transform[] spawningPoints;
	public GameObject[] grounds;
	public GameObject[] enemies;

	float x;

	// Use this for initialization
	void Start () {
		x = 40;
		StartCoroutine(SpawnEnemies());
	}

	IEnumerator SpawnEnemies() {
		while (true)
		{
			WaitForSeconds waitForSeconds = new WaitForSeconds(Random.Range(1.5f, 3f));
			if (Random.value > 0.5) // gnd
			{
				Instantiate(enemies[0], spawningPoints[0].position, Quaternion.identity);
			}
			else //air
			{
				Instantiate(enemies[1], spawningPoints[1].position, Quaternion.Euler(0f, 0f, 90f));
			}
			yield return waitForSeconds;
		}
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Floor"))
		{
			//print("[Spawn]"); // Spawn at x = 40
			Instantiate(Random.value > 0.5 ? grounds[0] : grounds[1], new Vector3(x, -2f), Quaternion.identity);
			x += 20;
			Destroy(collision.gameObject, 5f);
		}
		else
		{
			Destroy(collision.gameObject);
		}
	}
}
