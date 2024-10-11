using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int health;
    public GameObject particleOnDeath;
    public bool isMoving = false;
    public float immortalTime = 0;
    public bool isInvulnerable = false;
    private bool screenwrap = false;
    public bool isAlive = true;

    [SerializeField] public int scoreOnDeath;
    public ScoreManager scoreManager;

    public void GetDamage(int damage)
    {
        if (!isInvulnerable)
        {
            health -= damage;
            if (health < 1)
            {
                AddScore();
                if (particleOnDeath != null)
                {
                    Instantiate(particleOnDeath, transform.position, Quaternion.identity);
                }
                if(GetComponent<BaseEnemy>() != null)
                {
                    gameObject.SetActive(false);
                }
                isAlive = false;
            }
            else
            {
                StartCoroutine(countDownImmortal());
            }
        }
    }

    private IEnumerator countDownImmortal()
    {
        isInvulnerable = true;
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        for (int i = 0; i < 8; i++)
        {
            if(i % 2 == 0)
            {
                sprite.enabled = true;
            } else
            {
                sprite.enabled = false;
            }
            yield return new WaitForSeconds(immortalTime / 8);
        }
        sprite.enabled = true;
        isInvulnerable = false;
    }

    public IEnumerator lerpToPosition(Vector3 from, Vector3 to, float speed = 1, bool sine = false)
    {
        
        if (GetComponent<Screenwrap>() != null)
        {
            screenwrap = true;
        }
        isMoving = true;
        float steps = Mathf.Abs((from - to).magnitude) * 75 / speed;
        for (float i = 0; i < 1; i += 1 / steps)
        {
            int sineResult = 0;
            if(sine)
            {
                sineResult = 1;
            }
            transform.position = Vector3.Lerp(from, to + new Vector3(0, Mathf.Sin(i*10) * sineResult, 0), i);
            yield return new WaitForSeconds(0.005f);
            if(screenwrap && Mathf.Abs(transform.position.x) > Screen.width / (Screen.height / 5.5f))
            {
                float childIndex = (transform.position.x / Mathf.Abs(transform.position.x) * 2 + 2) / 4;
                transform.position = transform.GetChild((int)childIndex).position;
            }
            if (transform.position == to)
            {
                break;
            }
        }
        isMoving = false;
    }

    public virtual void AddScore()
    {
        if(scoreManager == null)
        {
            scoreManager = FindFirstObjectByType<ScoreManager>();
        }
    }
}
