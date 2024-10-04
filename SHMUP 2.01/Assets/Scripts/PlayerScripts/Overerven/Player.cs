using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : Character
{
    [SerializeField] public GameObject bullet;
    public Weapon weapon;

    public void Shoot()
    {
        GameObject newBullet = Instantiate(weapon.bullet, transform.position, Quaternion.identity);
        newBullet.tag = transform.tag;
        newBullet.transform.up = transform.up;
        newBullet.GetComponent<BulletMove>().damage = weapon.damage;
        newBullet.GetComponent<BulletMove>().bulletSpeed = weapon.bulletSpeed;
    }
}
