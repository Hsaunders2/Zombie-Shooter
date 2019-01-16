using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSpawner : MonoBehaviour {

    public GameObject enemy;
    public Transform enemyPos;
    public float timerRate, time2, howLong;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        InvokeRepeating("EnemySpawner", time2, timerRate);
        Destroy(gameObject, howLong);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    void EnemySpawner()
    {
        Instantiate(enemy, enemyPos.position, enemyPos.rotation);
    }
}
