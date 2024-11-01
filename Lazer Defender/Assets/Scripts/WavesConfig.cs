using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WavesConfig : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;

    [SerializeField] Transform pathPrefab;

    float moveSpeed = 5f;
    float timeBetweenEnemySpawns = 1.5f;
    float timeSpawnVarians = 0f;
    float minimumSpawnTime = 0.2f;

    public float GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public List<Transform> GetOtherWayPoints()
    {
        List<Transform> wayPoints = new List<Transform>();

        foreach(Transform child in pathPrefab)
        {
            wayPoints.Add(child);
        }
        
        return wayPoints;
    }

    public Transform GetStartWayPoint()
    {
        return pathPrefab.GetChild(0);
    }
    
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - timeSpawnVarians, timeBetweenEnemySpawns + timeSpawnVarians);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}
