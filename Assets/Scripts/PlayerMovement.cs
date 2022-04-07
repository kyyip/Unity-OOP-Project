using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject dodgeBall;
    [SerializeField] GameObject reticle;
    [SerializeField] float moveSpeedMax = 80f;
    [SerializeField] float throwForce = 100f;
    [SerializeField] float rotateSpeedMax = 20f;
    [SerializeField] int maxBalls = 10;

    private int balls = 1;
    private bool alive = true;
    private float moveSpeed;
    private float rotateSpeed;

    public static PlayerMovement Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    //ENCAPSULATION
    public int Balls
    {
        get { return balls; }
        set { if (value >= 0 & value <= maxBalls)
            {
                balls = value;
            } 
        }
    }

    public float MoveSpeed
    {
        get { return moveSpeed; }
        set
        {
            if (value >= 0)
            {
                moveSpeed = value;
                if (moveSpeed > moveSpeedMax)
                {
                    moveSpeed = moveSpeedMax;
                }
            }
        }
    }

    public float RotateSpeed
    {
        get { return rotateSpeed; }
        set
        {
            if (value >= 0)
            {
                rotateSpeed = value;
                if (rotateSpeed > rotateSpeedMax)
                {
                    rotateSpeed = rotateSpeedMax;
                }
            }
        }
    }

    public bool Alive
    {
        get { return alive; }
    }

    // Start is called before the first frame update
    void Start()
    {
        MoveSpeed = moveSpeedMax / 2;
        RotateSpeed = rotateSpeedMax / 2;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ThrowBall();

    }


    // ABSTRACTION
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
        if (Input.GetKeyDown(KeyCode.Space) && Balls > 0)
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            alive = false;
        }
    }
}
