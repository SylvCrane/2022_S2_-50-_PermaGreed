using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    int numberOfEnemy;
    int maxEnemy;

    [SerializeField] GameObject meeleEnemy;
    [SerializeField] GameObject rangeEnemy;

    bool canSpawn;
    private float spawnTimer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        //implement max number of enemy later
        canSpawn = true; //the state of enemy spawn, can it spawn ?
    }

    // Update is called once per frame
    void Update()
    {
        spawn();
    }

    private void spawn()
    {
        int enemyType = Random.Range(0, 2); //randomly decide if an enemy is range or melee

        if (canSpawn == true)
        {
            if (enemyType == 1)
            {
                GameObject newEnemy = Instantiate(meeleEnemy); 
            }

            if(enemyType == 0)
            {
                GameObject newEnemy = Instantiate(rangeEnemy);
            }

            canSpawn = false;
            StartCoroutine(spawnEnemyCoolDown(5f)); 
        }  
    }

    private IEnumerator spawnEnemyCoolDown(float interval) //spawn enemy cooldown
    {
        yield return new WaitForSeconds(interval);
        canSpawn = true;
    }
}
