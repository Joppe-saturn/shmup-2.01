using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] public GameObject bullet;
    public Weapon weapon;
    private bool canShoot = true;

    public void Shoot()
    {
        if(canShoot)
        {
            GameObject newBullet = Instantiate(weapon.bullet, transform.position, Quaternion.identity);
            newBullet.tag = transform.tag;
            newBullet.transform.up = transform.up;
            newBullet.GetComponent<BulletMove>().damage = weapon.damage;
            newBullet.GetComponent<BulletMove>().bulletSpeed = weapon.bulletSpeed;
            StartCoroutine(shootCoolDown());
        }
    }

    private IEnumerator shootCoolDown()
    {
        canShoot = false;
        yield return new WaitForSeconds(weapon.cooldown);
        canShoot = true;
    }
}
