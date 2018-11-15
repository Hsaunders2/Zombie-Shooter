using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {

    public GameObject zombiePrefab;
    public Transform zombieSpawn;
    public Transform player;
    public float spawnTime = 0.5f;

    private bool isSpawning = false;

    private void SetSpawning()
    {
        isSpawning = false;
    }

	private void Spawn()
    {
        isSpawning = true;
        GameObject zombie = Instantiate(zombiePrefab, zombieSpawn.position, zombieSpawn.rotation);

        zombie.GetComponent<SmoothLookAtTarget>().target = player;
        zombie.GetComponent<MoveTowardsTarget>().target = player;

        Invoke("SetSpawning", spawnTime);
    }
	
	// Update is called once per frame
	void Update () {
        if (!isSpawning)
        {
            Spawn();
        }
	}
}
