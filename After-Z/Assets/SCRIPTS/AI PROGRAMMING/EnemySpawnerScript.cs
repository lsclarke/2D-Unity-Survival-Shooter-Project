using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    //Reference to the bullet spawn point, and the projectile itself
    [Header("Refernce Settings")]
    [SerializeField] public GameObject[] enemyPrefab;

    [Space(2)]
    //Spawn Variables
    [Header("Spawn Settings")]
    public float spawnRate;
    public bool canSpawn;
    [Space(2)]
    public int currentEnemyNum;
    public int maxEnemyNum;

    private enum EnemyType { regular, special }
    [SerializeField] private EnemyType type;

    // Start is called before the first frame update
    void Awake()
    {
        //Spawn regular enmeies first when the game starts
        type = EnemyType.regular;
        canSpawn = true;
        StartCoroutine(Spawner());
        currentEnemyNum = 0;

    }

    public void SpawnController()
    {
        StartCoroutine(Spawner());
        if (!canSpawn)
        {
            StopCoroutine(Spawner());

        }
    }

    //When canSpawn is true and the amount of enemies in the world is less than the current max,
    //spawn more enemies
    private IEnumerator Spawner()
    {
        WaitForSeconds sec = new WaitForSeconds(spawnRate);

        while (canSpawn && currentEnemyNum < maxEnemyNum)
        {
           yield return sec;
            int randomInt = UnityEngine.Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[randomInt], transform.position, Quaternion.identity);
            currentEnemyNum++;
          
        }  
    }
}
