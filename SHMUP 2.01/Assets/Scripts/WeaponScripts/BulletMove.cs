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
}
