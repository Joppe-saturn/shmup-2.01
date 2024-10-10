using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : BaseEnemy
{
    public float shootingSpeed;
    [SerializeField] public Weapon weapon;
    public Vector3 defaultPosition;

    public enum attackState
    {
        down,
        toPlayer
    }

    public attackState state;

    public void Shoot(Vector3 target)
    {
        GameObject newBullet = Instantiate(weapon.bullet, transform.position, Quaternion.identity);
        newBullet.tag = transform.tag;
        newBullet.transform.up = target - transform.position; //I got this from https://discussions.unity.com/t/lookat-2d-equivalent/88118/12
        newBullet.GetComponent<BulletMove>().damage = weapon.damage;
        newBullet.GetComponent<BulletMove>().bulletSpeed = weapon.bulletSpeed;
    }

    public IEnumerator attackCycle()
    {
        while (isMoving)
        {
            yield return null;
        }
        while (true)
        {
            yield return new WaitForSeconds(shootingSpeed * 2);
            switch (state)
            {
                case attackState.down:
                    Shoot(new Vector3(transform.position.x, -100, transform.position.z));
                    break;
                case attackState.toPlayer:
                    Shoot(player.transform.position);
                    break;
            }
        }
    }
}
