using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : ShootingEnemy
{
    private void Start()
    {
        if (GetComponent<Enemy3>() == null)
        {
            MoveToStartPos();
            StartCoroutine(attackCycle());
        }
    }

    public void SetUp()
    {
        StartCoroutine(attackCycle());
    }

    private void Update()
    {
        shootingSpeed = 1.0f / (waveManager.currentWave / 4.0f);       
        weapon.projectileCount = 1 + (int)Mathf.Round(waveManager.currentWave / 2);
    }
}
