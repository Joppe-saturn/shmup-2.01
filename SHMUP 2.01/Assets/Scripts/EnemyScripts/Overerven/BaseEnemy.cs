using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseEnemy : Character
{
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject dropLoot;
    [SerializeField] public Wavemanager waveManager;
    [SerializeField] public bool immortalPlayerCollision = false;
    
    private void Awake()
    {
        if(player == null) 
        {
            player = FindFirstObjectByType<Player>().gameObject;
        }
        if (waveManager == null)
        {
            waveManager = FindFirstObjectByType<Wavemanager>();
        }
        StartCoroutine(OffscreenImmunity());
    }

    private void Update()
    {
        if(!player.GetComponent<Player>().isAlive)
        {
            isMoving = true;
        }
    }

    public void MoveToStartPos(float speed = 1)
    {
        StartCoroutine(lerpToPosition(transform.position, new Vector3(Random.Range(-Screen.width / (Screen.height / 1.75f), Screen.width / (Screen.height / 1.75f)), Random.Range(0.0f, Screen.height / (Screen.width / 2.5f)), 0), speed, false));
    }

    private IEnumerator OffscreenImmunity()
    {
        isInvulnerable = true;
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        while(!renderer.isVisible)
        {
            yield return null;
        }
        yield return new WaitForSeconds(0.05f);
        isInvulnerable = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>() != null)
        {
            collision.GetComponent<Player>().GetDamage(1);
            if(!immortalPlayerCollision)
            {
                isInvulnerable = false;
                GetDamage(100000);
            }
        }
    }

    public override void AddScore()
    {
        base.AddScore();
        if(player.GetComponent<Player>().isAlive)
        {
            scoreManager.score += Mathf.FloorToInt(scoreOnDeath * (player.GetComponent<Player>().health / 3.0f));
        }
    }
}
