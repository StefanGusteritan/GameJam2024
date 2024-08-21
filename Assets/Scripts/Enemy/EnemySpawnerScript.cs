using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField] List<GameObject> enemies = new List<GameObject>();
    float spawnTimer, spawnTime;
    Transform cameraTransform;
    [SerializeField] float heightStartOffset, heightEndOffset, widthStartOffset, widthEndOffset;

   int basicEnemySpawnChanse, shooterEnemySpawnChanse, explodeEnemySpawnChanse;
    [SerializeField] float[] whaveSpawnTimes;
    [SerializeField] int[] waveBasicEnemySpawnChanses, waveShooterEnemySpawnChanses, waveExplodeEnemySpawnChanses;

    private void Start() {
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTime > 0)
        {
            if (spawnTimer < spawnTime)
                spawnTimer += Time.deltaTime;
            else
            {
                spawnTimer = 0;
                int enemyType = Random.Range(1, 101);
                enemyType = (enemyType <= basicEnemySpawnChanse)? 0 : 
                    (enemyType <= basicEnemySpawnChanse + shooterEnemySpawnChanse)? 1 : 2;
                spawn(enemies[enemyType]);
            }
        }
    }

    void spawn(GameObject enemy)
    {
        //Seting the spawn pozition
        Vector2 spawnPozition = cameraTransform.position;
        int up = (Random.Range(0,2) == 0)? -1 : 1, right = (Random.Range(0,2) == 0)? -1 : 1;
        spawnPozition.x += right * Random.Range(widthStartOffset, widthEndOffset);
        spawnPozition.y += up * Random.Range(heightStartOffset, heightEndOffset);

        //Instantiating GameObject
        Instantiate(enemy, spawnPozition, transform.rotation);
        Debug.Log(enemy.name + " spawned at: " + spawnPozition);
    }

    public void SetWave(int wave)
    {
        spawnTime = whaveSpawnTimes[wave];
        spawnTimer = 0;
        basicEnemySpawnChanse = waveBasicEnemySpawnChanses[wave];
        shooterEnemySpawnChanse = waveShooterEnemySpawnChanses[wave];
        explodeEnemySpawnChanse = waveExplodeEnemySpawnChanses[wave];
    }
}
