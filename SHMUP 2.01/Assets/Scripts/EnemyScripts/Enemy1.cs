using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MovingEnemy
{
    private void Start()
    {
        speed = 1.0f + (waveManager.currentWave / 4.0f);
        if(GetComponent<Enemy3>() == null )
        {
            MoveToStartPos(speed);
            StartCoroutine(startMoveCycle());
        }
    }

    public void SetUp()
    {
        StartCoroutine(startMoveCycle());
    }

    private void Update()
    {
        speed = 1.0f + (waveManager.currentWave / 4.0f);
    }
}
