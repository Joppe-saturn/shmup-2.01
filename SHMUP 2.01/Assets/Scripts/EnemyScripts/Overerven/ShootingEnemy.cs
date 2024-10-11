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
        while (player.GetComponent<Player>().isAlive)
        {
            yield return new WaitForSeconds(shootingSpeed * 2);
            switch (state)
            {
                case attackState.down:
                    for(int i = 0; i < weapon.projectileCount; i++)
                    {
                        Shoot(new Vector3(transform.position.x, -100, transform.position.z));
                        yield return new WaitForSeconds(0.25f);
                    }
                    break;
                case attackState.toPlayer:
                    for (int i = 0; i < weapon.projectileCount; i++)
                    {
                        Shoot(player.transform.position);
                        yield return new WaitForSeconds(0.25f);
                    }
                    break;
            }
        }
    }
}
