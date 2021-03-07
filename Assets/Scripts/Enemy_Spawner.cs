using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public float nextSpawn = 0.0f;
    public float spawnrate = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Boss").Length > 0)
        {
            spawn();
        }
        
    }

    void spawn()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnrate;
            Instantiate(enemy, transform.position, Quaternion.identity);
        }
    }
}
