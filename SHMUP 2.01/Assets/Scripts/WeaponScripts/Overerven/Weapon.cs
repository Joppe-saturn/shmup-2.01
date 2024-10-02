using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] public GameObject bullet;
    public int projectileCount;
    public int damage;
    public float bulletSpeed;
}
