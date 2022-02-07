using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random=UnityEngine.Random;

[Serializable] 
public struct EnemySpawnerSpot{
    public GameObject enemy;
    public Vector2 xRange, yRange;
    public float timer;
    public int count;
}

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemySpawnerSpot[] spawnSpots;
    private float[] subTimers;

    private void Start() {
        subTimers = new float[spawnSpots.Length];
        for (int idx = 0; idx < subTimers.Length; idx++){
            subTimers[idx] = 0;
        }
    }

    private void Update(){
        for (int idx = 0; idx < subTimers.Length; idx++){
            if (subTimers[idx] >= spawnSpots[idx].timer){
                subTimers[idx] = 0;
                SpawnEnemy(idx);
            }
            else {
                subTimers[idx] += Time.deltaTime;
            }
        }
    }

    private void SpawnEnemy(int index){
        int count = spawnSpots[index].count;
        for (int i = 0; i < count; i++){
            Vector2 xRange = spawnSpots[index].xRange;
            Vector2 yRange = spawnSpots[index].yRange;
            float posX = Random.Range(xRange.x, xRange.y);
            float posY = Random.Range(yRange.x, yRange.y);
            Vector3 position = new Vector3(posX, posY, 0);
            Instantiate(spawnSpots[index].enemy, position, Quaternion.identity);
        }
    }
}
