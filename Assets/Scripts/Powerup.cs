using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] float rotSpeed = 100f;

    private void Update()
    {
        transform.Rotate(0, 0, -rotSpeed * Time.deltaTime);
    }
    public virtual void Activate()
    {
        PlayerMovement.Instance.Balls += 1;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Activate();
        }
    }
}
