using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float bulletSpeed;
    public int damage;
    private Renderer rb;

    private void Start()
    {
        rb = GetComponent<Renderer>();
    }

    private void Update()
    {
        transform.position += transform.up * bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag != transform.tag && collision.transform.GetComponent<Character>() != null)
        {
            collision.transform.GetComponent<Character>().GetDamage(damage);
            Destroy(gameObject);
        }
    }
}
