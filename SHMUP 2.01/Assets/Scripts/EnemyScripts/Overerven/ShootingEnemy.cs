using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : BaseEnemy
{
    public float shootingSpeed;
    public Weapon weapon;
    public Vector3 defaultPosition;

    private void Start()
    {
        weapon = GetComponent<Weapon>();
    }

    private void Update()
    {
        shootingSpeed = 1 + (/*currentWave*/ 1 / 4);
        weapon.projectileCount = 1 + Math.Abs(/*currentWave*/ 1 / 2);
    }

    public void Shoot(Vector3 target)
    {
        GameObject newBullet = Instantiate(weapon.bullet, transform.position, Quaternion.identity);
        newBullet.transform.up = target - transform.position - transform.position; //I got this from https://discussions.unity.com/t/lookat-2d-equivalent/88118/12
    }
}
