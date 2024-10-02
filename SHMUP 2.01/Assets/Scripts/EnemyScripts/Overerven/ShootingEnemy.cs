using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : BaseEnemy
{
    public float shootingSpeed;
    [SerializeField] public Weapon weapon;
    public Vector3 defaultPosition;

    private void Update()
    {
        shootingSpeed = 1 + (/*currentWave*/ 1 / 4);
        weapon.projectileCount = 1 + Math.Abs(/*currentWave*/ 1 / 2);
    }

    public void Shoot(Vector3 target)
    {
        GameObject newBullet = Instantiate(weapon.bullet, transform.position, Quaternion.identity);
        newBullet.tag = transform.tag;
        newBullet.transform.up = target - transform.position; //I got this from https://discussions.unity.com/t/lookat-2d-equivalent/88118/12
        newBullet.GetComponent<BulletMove>().damage = weapon.damage;
        newBullet.GetComponent<BulletMove>().bulletSpeed = weapon.bulletSpeed;
    }
}
