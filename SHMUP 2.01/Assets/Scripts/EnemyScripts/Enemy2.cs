using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : ShootingEnemy
{
    public enum attackState
    {
        down,
        toPlayer
    }

    public attackState state;

    private void Start()
    {
        StartCoroutine(lerpToPosition(transform.position, new Vector3(Random.Range(-8.0f, 8.0f), Random.Range(0.0f, 4.0f), 0)));
        StartCoroutine(attackCycle());
    }

    private IEnumerator attackCycle()
    {
        while(isMoving)
        {
            yield return null;
        }
        while (true)
        {
            yield return new WaitForSeconds(shootingSpeed);
            switch (state)
            {
                case attackState.down:
                    Shoot(new Vector3(transform.position.x, 0, 0));
                    break;
                case attackState.toPlayer: 
                    Shoot(player.transform.position);
                    break;
            }
        }
    }
}
