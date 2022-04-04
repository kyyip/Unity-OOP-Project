using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerup: Powerup
{
    // Start is called before the first frame update
    public override void Activate()
    {
        PlayerMovement.Instance.MoveSpeed *= 1.1f;
        PlayerMovement.Instance.RotateSpeed *= 1.1f;
        Destroy(gameObject);
    }
}
