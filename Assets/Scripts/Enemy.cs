using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] bool isOnGround = false;
    [SerializeField] GameObject[] powerups;

    private Rigidbody enemyRb;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnGround)
        {
            MoveToPlayer();

            if (transform.position.y < 1.5f | transform.position.y > 2f)
            {
                transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
            }
        }
    }

    private void MoveToPlayer()
    {
        Vector3 moveDir = PlayerMovement.Instance.transform.position - transform.position;
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    private void OnDestroy()
    {
        int index = Random.Range(0, powerups.Length + 2);
        if (index < 2) {
            Instantiate(powerups[index], transform.position, powerups[index].transform.rotation);
        }
        
    }
}
