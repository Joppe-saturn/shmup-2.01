using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : BaseEnemy
{
    public float speed;

    private void Update()
    {
        speed = 1 + (/*currentWave*/ 1 / 4);
    }
}
