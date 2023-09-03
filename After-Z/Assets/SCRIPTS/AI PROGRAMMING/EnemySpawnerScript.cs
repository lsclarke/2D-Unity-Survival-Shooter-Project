using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    //Reference to the bullet spawn point, and the projectile itself
    [Header("Refernce Settings")]
    [SerializeField] private GameObject[] enemyPrefab;

    [Space(2)]
    //Spawn Variables
    [Header("Spawn Settings")]
    public float spawnRate;
    public bool canSpawn;
    private enum EnemyType { regular, special }
    [SerializeField] private EnemyType type;


    // Start is called before the first frame update
    void Start()
    {
        //Spawn regular enmeies first when the game starts
        type = EnemyType.regular;
        canSpawn = true;

        StartCoroutine(Spawner());
    }
    private void FixedUpdate()
    {
     
    }

    public void SpawnEnemies(Enum enemy)
    {
        switch (type)
        {
            case EnemyType.regular:
                break;
            case EnemyType.special:
                break;

        }
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds sec = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
           yield return sec;
            int randomInt = UnityEngine.Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[randomInt], transform.position, Quaternion.identity);
            

        }
        
    }
}
