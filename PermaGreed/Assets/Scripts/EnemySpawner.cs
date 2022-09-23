using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    int numberOfEnemy;
    int maxEnemy;

    [SerializeField] GameObject meeleEnemy;
    [SerializeField] GameObject rangeEnemy;

    private float spawnTimer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        numberOfEnemy = 0;
        maxEnemy = 1;
        spawn(1);
        spawn(0);
    }

    // Update is called once per frame
    void Update()
    {
        spawn(1);
        spawn(0);
        //StartCoroutine(spawnEnemy(interval, enemy));
    }

    private void spawn(int enemyType)
    {
        if (enemyType == 1)
        {
            GameObject newEnemy = Instantiate(meeleEnemy); 
        }

        if(enemyType == 0)
        {
            GameObject newEnemy = Instantiate(rangeEnemy);
        }
        
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(10f);
        GameObject newEnemy = Instantiate(enemy, new Vector3(877, 3, -346), Quaternion.identity);

    }

    private bool checkTimer()
    {
        return false;
    }
}
