using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnRange = 15f;
    [SerializeField] GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 5f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnEnemy()
    {
        Instantiate(enemies[0], new Vector3(Random.Range(-spawnRange, spawnRange), 15f, Random.Range(-spawnRange, spawnRange)), transform.rotation);
    }
}
