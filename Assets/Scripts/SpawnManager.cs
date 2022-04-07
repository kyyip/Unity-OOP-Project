using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnRange = 15f;
    [SerializeField] GameObject[] enemies;

    private float maxTimer = 3f;
    private float timer;
    private float minTimer = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        timer = maxTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.Instance.Alive)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                maxTimer *= 0.98f;

                if (maxTimer <= 0.5f)
                {
                    maxTimer = minTimer;
                }

                timer = maxTimer;

                SpawnEnemy();
            }
        }

    }


    private void SpawnEnemy()
    {
        Instantiate(enemies[0], new Vector3(Random.Range(-spawnRange, spawnRange), 15f, Random.Range(-spawnRange, spawnRange)), transform.rotation);
    }
}
