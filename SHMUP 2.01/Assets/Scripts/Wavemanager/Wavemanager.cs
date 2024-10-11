using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Wavemanager : MonoBehaviour
{
    [System.Serializable]
    public class EnemyGroep
    {
        public List<GameObject> enemies = new List<GameObject>();
    }
    
    [System.Serializable]
    public class Wave
    {
        public List<EnemyGroep> enemyGroeps = new List<EnemyGroep>();
        public float spawnInterval;
    }

    public int currentWave = 1;
    private int currentGroup = 0;
    [SerializeField] private List<Wave> waves = new List<Wave>();

    private float spawnTimer;
    private List<GameObject> enemiesOnScreen = new List<GameObject>();
    private bool canSpawn = true;

    private void Start()
    {
        currentWave = 1;
        StartCoroutine(WaveSpawner());
    }

    private IEnumerator WaveSpawner()
    {
        spawnTimer = waves[currentWave - 1].spawnInterval;
        yield return null;
        while (true)
        {
            int realCurrentWave = (currentWave - 1) % waves.Count;
            if (spawnTimer > waves[realCurrentWave].spawnInterval)
            {
                spawnTimer = 0;
                for(int i = 0; i < waves[realCurrentWave].enemyGroeps[currentGroup].enemies.Count; i++)
                {
                    if(canSpawn)
                    {
                        enemiesOnScreen.Add(Instantiate(waves[realCurrentWave].enemyGroeps[currentGroup].enemies[i], transform.position, Quaternion.identity));
                        GameObject currentEnemy = enemiesOnScreen[enemiesOnScreen.Count - 1];
                        if (currentEnemy.GetComponent<MovingEnemy>() != null)
                        {
                            if(Random.Range(0, 2) == 0)
                            {
                                currentEnemy.GetComponent<MovingEnemy>().moveState = MovingEnemy.MoveState.leftRight;
                            } else
                            {
                                currentEnemy.GetComponent<MovingEnemy>().moveState = MovingEnemy.MoveState.toPlayer;
                            }
                        }
                        if (currentEnemy.GetComponent<ShootingEnemy>() != null)
                        {
                            if (Random.Range(0, 2) == 0)
                            {
                                currentEnemy.GetComponent<ShootingEnemy>().state = ShootingEnemy.attackState.down;
                            }
                            else
                            {
                                currentEnemy.GetComponent<ShootingEnemy>().state = ShootingEnemy.attackState.toPlayer;
                            }
                        }
                        if (currentEnemy.GetComponent<Boss>() != null)
                        {
                            currentEnemy.GetComponent<Boss>().state = ShootingEnemy.attackState.toPlayer;

                            int outPut = Random.Range(0, 3);
                            if (outPut == 0)
                            {
                                currentEnemy.GetComponent<Boss>().moveState = Boss.MoveState.still;
                            }
                            else if (outPut == 1) 
                            {
                                currentEnemy.GetComponent<Boss>().moveState = Boss.MoveState.leftRight;
                            } else
                            {
                                currentEnemy.GetComponent<Boss>().moveState = Boss.MoveState.sine;
                            }
                        }
                    }
                }
                if(currentGroup < waves[realCurrentWave].enemyGroeps.Count - 1)
                {
                    currentGroup++;
                    canSpawn = true;
                } else
                {
                    canSpawn = false;
                }
            }

            int enemiesDead = 0;
            int totalEnemies = 0;
            for(int i = 0; i < enemiesOnScreen.Count; i++)
            {
                if (!enemiesOnScreen[i].activeSelf)
                {
                    enemiesDead++;
                }
            }
            for(int i = 0;i < waves[realCurrentWave].enemyGroeps.Count; i++)
            {
                totalEnemies += waves[realCurrentWave].enemyGroeps[i].enemies.Count;
            }
            if(enemiesDead == totalEnemies)
            {
                currentGroup = 0;
                currentWave++;
                spawnTimer = 0;
                canSpawn = true;
                for (int i = 0; i < enemiesDead; i++)
                {
                    Destroy(enemiesOnScreen[i]);
                }
                enemiesOnScreen.Clear();
            }
            spawnTimer += 0.02f;
            yield return new WaitForSeconds(0.02f);
        }
    }
}
