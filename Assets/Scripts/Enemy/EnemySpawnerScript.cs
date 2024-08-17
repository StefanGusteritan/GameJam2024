using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField] List<GameObject> enemies = new List<GameObject>();
    [SerializeField] float spawnTime;
    float spawnTimer;
    Transform cameraTransform;
    [SerializeField] float heightStartOffset, heightEndOffset, widthStartOffset, widthEndOffset;

    private void Start() {
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer < spawnTime)
            spawnTimer += Time.deltaTime;
        else
        {
            spawnTimer = 0;
            int enemyType = Random.Range(0, enemies.Count);
            spawn(enemies[enemyType]);
        }
    }

    void spawn(GameObject enemy)
    {
        //Seting the spawn pozition
        Vector2 spawnPozition = cameraTransform.position;
        int up = (Random.Range(0,2) == 0)? -1 : 1, right = (Random.Range(0,2) == 0)? -1 : 1;
        spawnPozition.x = right * Random.Range(widthStartOffset, widthEndOffset);
        spawnPozition.y = up * Random.Range(heightStartOffset, heightEndOffset);

        //Instantiating GameObject
        Instantiate(enemy, spawnPozition, transform.rotation);
        Debug.Log(enemy.name + " spawned at: " + spawnPozition);
    }
}
