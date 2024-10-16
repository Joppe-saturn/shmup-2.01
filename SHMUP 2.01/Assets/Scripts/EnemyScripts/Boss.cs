using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Boss : ShootingEnemy
{
    public enum MoveState
    {
        still,
        leftRight,
        sine
    }

    public MoveState moveState;

    private void Awake()
    {
        if (waveManager == null)
        {
            waveManager = FindFirstObjectByType<Wavemanager>();
        }
        if (player == null)
        {
            player = FindFirstObjectByType<Player>().gameObject;
        }
        health = 4 * waveManager.currentWave + 12;
        shootingSpeed = 1.0f / (waveManager.currentWave / 4.0f);
        weapon.projectileCount = 1 + (int)Mathf.Round(waveManager.currentWave / 2);
        StartCoroutine(attackCycle());
        MoveToStartPos();
        StartCoroutine(startMoveCycle());
    }

    private IEnumerator startMoveCycle()
    {
        while (player.GetComponent<Player>().isAlive)
        {
            while (isMoving)
            {
                yield return null;
            }
            switch (moveState)
            {
                case MoveState.leftRight:
                    StartCoroutine(lerpToPosition(transform.position, new Vector3(Mathf.Abs(transform.position.x) / transform.position.x * -(Screen.height / (Screen.width / 1.75f)), transform.position.y, 0)));
                    break;
                case MoveState.sine:
                    StartCoroutine(lerpToPosition(transform.position, new Vector3(Mathf.Abs(transform.position.x) / transform.position.x * -(Screen.height / (Screen.width / 1.75f)), Mathf.Sin(transform.position.y), 0), 1, true));
                    break;
            }
            yield return null;
        }
    }
}
