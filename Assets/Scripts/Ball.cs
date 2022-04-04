using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float posLimit = 18.5f;
    
    private Rigidbody ballRb;

    private void Start()
    {
        ballRb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        ConstrainBall();
    }

    //Keep the ball from falling out of the arena
    private void ConstrainBall()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -posLimit, posLimit);
        pos.z = Mathf.Clamp(pos.z, -posLimit, posLimit);
        transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && ballRb.velocity.magnitude>0.5)
        {
            Destroy(collision.gameObject);
        }
    }

    
}
