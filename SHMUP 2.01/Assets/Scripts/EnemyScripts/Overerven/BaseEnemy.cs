using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : Character
{
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject dropLoot;

    public void MoveToStartPos(float speed = 1)
    {
        StartCoroutine(lerpToPosition(transform.position, new Vector3(Random.Range(-8.0f, 8.0f), Random.Range(0.0f, 4.0f), 0), speed));
    }
}
