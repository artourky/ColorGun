using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour {

	public Transform[] spawningPoints;

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnEnemies());
	}

	IEnumerator SpawnEnemies() {
		while (true)
		{
			WaitForSeconds waitForSeconds = new WaitForSeconds(Random.Range(0.5f, 3f));
			yield return waitForSeconds;
		}
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Floor"))
		{
			print("Spawn"); // Spawn at x = 40
		}
	}
}
