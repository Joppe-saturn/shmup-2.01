using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : BaseEnemy
{
    public float speed;
    public enum MoveState
    {
        leftRight,
        toPlayer
    }

    public MoveState moveState;

    public IEnumerator startMoveCycle()
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
                    StartCoroutine(lerpToPosition(transform.position, new Vector3(Mathf.Abs(transform.position.x) / transform.position.x * -(Screen.height / (Screen.width / 1.75f)), transform.position.y, 0), speed));
                    break;
                case MoveState.toPlayer:
                    StartCoroutine(lerpToPosition(transform.position, new Vector3(Mathf.Abs(transform.position.x) / transform.position.x * -(Screen.height / (Screen.width / 1.75f)), transform.position.y + (player.transform.position.y - transform.position.y) / 5, 0), speed));
                    break;
            }
            yield return null;
        }
    }
}
