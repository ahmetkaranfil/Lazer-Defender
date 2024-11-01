using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    WavesConfig currentWave;
    [SerializeField] List<WavesConfig> wavesConfig;
    [SerializeField] float timeBetweenWave = 0f;
    [SerializeField] bool isLooping;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    public WavesConfig GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnEnemyWaves()
    {
        do{
            foreach (WavesConfig wave in wavesConfig)
            {
                currentWave = wave;
                for(int i=0; i<currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i),
                                currentWave.GetStartWayPoint().position, 
                                Quaternion.Euler(0,0,180),
                                transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWave);
            }
        }
        while(isLooping);
    }
}