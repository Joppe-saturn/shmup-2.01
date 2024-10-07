using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : Character
{
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject dropLoot;

    private void Awake()
    {
        if(player == null) {
            player = FindFirstObjectByType<Player>().gameObject;
        }
    }

    public void MoveToStartPos(float speed = 1)
    {
        StartCoroutine(lerpToPosition(transform.position, new Vector3(Random.Range(-Screen.width / (Screen.height / 2), Screen.width / (Screen.height / 2)), Random.Range(0.0f, Screen.height / (Screen.width / 2.5f)), 0), speed));
    }
}
