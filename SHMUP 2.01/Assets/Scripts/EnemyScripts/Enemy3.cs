using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : BaseEnemy
{
    private Enemy1 movingEnemy;
    private Enemy2 shootingEnemy;

    private void Start()
    {
        movingEnemy = GetComponent<Enemy1>();
        shootingEnemy = GetComponent<Enemy2>();
        movingEnemy.player = player;
        shootingEnemy.player = player;
        MoveToStartPos();
        StartCoroutine(activateShootingAndMoving());
    }

    private IEnumerator activateShootingAndMoving()
    {
        while(isMoving)
        {
            yield return null;
        }
        movingEnemy.SetUp();
        shootingEnemy.SetUp();
    }
}
