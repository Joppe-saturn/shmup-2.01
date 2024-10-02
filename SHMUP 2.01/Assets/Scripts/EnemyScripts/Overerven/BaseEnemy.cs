using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] public GameObject player;
    public int health;
    public GameObject dropLoot;
    public GameObject particleOnDeath;
    public bool isMoving = false;

    public void GetDamage(int damage)
    {
        health -= damage;
        if (health < 1)
        {
            if(particleOnDeath != null)
            {
                Instantiate(particleOnDeath, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

    public IEnumerator lerpToPosition(Vector3 from, Vector3 to, float speed = 1)
    {
        isMoving = true;
        for (float i = 0; i < Mathf.Abs((from - to).magnitude) * 100; i += 0.1f / Mathf.Abs((from - to).magnitude))
        {
            transform.position = Vector3.Lerp(from, to, i);
            yield return new WaitForSeconds(0.02f / speed);
            if(transform.position == to)
            {
                break; 
            }
        }
        isMoving = false;
    }
}
