using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueSpiritSpawner : MonoBehaviour
{

    public GameObject blueSpiritPrefab;
    public Transform spawn;
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
        GameObject blueSpirit = Instantiate(blueSpiritPrefab, spawn.position, spawn.rotation);

        blueSpirit.GetComponent<MoveTowardsTarget>().target = player;

        Invoke("SetSpawning", spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawning)
        {
            Spawn();
        }
    }
}