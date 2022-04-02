using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject dodgeBall;
    [SerializeField] float moveSpeed = 40f;
    [SerializeField] float throwForce = 100f;
    private float spawnOffset = 5f;
    private int balls = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ThrowBall();

    }

    private void MovePlayer()
    {
        Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;

        transform.Translate(moveVector * Time.deltaTime * moveSpeed);
    }

    private void ThrowBall()
    {
        if (Input.GetKeyDown(KeyCode.Space) && balls > 0)
        {
            dodgeBall = Instantiate(dodgeBall, transform.position + new Vector3(0, 0, spawnOffset), transform.rotation);
            dodgeBall.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, throwForce), ForceMode.Impulse);
            balls -= 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DodgeBall"))
        {
            balls += 1;
            Destroy(other.gameObject);
        }
    }
}
