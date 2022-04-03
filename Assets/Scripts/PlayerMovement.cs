using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject dodgeBall;
    [SerializeField] GameObject reticle;
    [SerializeField] float moveSpeed = 40f;
    [SerializeField] float throwForce = 100f;
    [SerializeField] float rotateSpeed = 10f;

    private int balls = 1;


    public int Balls
    {
        get { return balls; }
        set { if (value > 0)
            {
                balls = value;
            } 
        }
    }
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
        Vector3 moveVector = new Vector3(0f, 0f, Input.GetAxis("Vertical"));

        transform.Translate(moveVector * Time.deltaTime * moveSpeed);
        transform.Rotate(0f, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0f);

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -18f, 18f);
        pos.z = Mathf.Clamp(pos.z, -18f, 18f);
        transform.position = pos;
    }

    private void ThrowBall()
    {
        if (Input.GetKeyDown(KeyCode.Space) && balls > 0)
        {
            GameObject newBall = Instantiate(dodgeBall, reticle.transform.position, transform.rotation);
            newBall.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * throwForce);
            Balls -= 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DodgeBall"))
        {
            Balls += 1;
            Destroy(other.transform.parent.gameObject);
        }
    }
}
