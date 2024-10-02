using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MovingEnemy
{
    public enum MoveState
    {
        leftRight,
        toPlayer
    }

    public MoveState moveState;

    private void Start()
    {
        StartCoroutine(lerpToPosition(transform.position, new Vector3(Random.Range(-8.0f, 8.0f), Random.Range(0.0f, 4.0f), 0), speed));
        StartCoroutine(startMoveCycle());
    }

    private IEnumerator startMoveCycle()
    {
        while (true)
        {
            while (isMoving)
            {
                yield return null;
                Debug.Log(1);
            }
            switch(moveState)
            {
                case MoveState.leftRight:
                    lerpToPosition(transform.position, new Vector3((transform.position.x - (transform.position.x * -1)) * 4, transform.position.y, 0), speed);
                    break;
                case MoveState.toPlayer:
                    lerpToPosition(transform.position, new Vector3((transform.position.x - (transform.position.x * -1)) * 4, (transform.position.y - player.transform.position.y) / 5, 0), speed);
                    break;
            }
        }
    }
}
