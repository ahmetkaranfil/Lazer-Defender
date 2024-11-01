using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WavesConfig wavesConfig;
    List<Transform> wayPoints;
    int wayPointsIndex = 0;

    void Awake()
    {
        enemySpawner = FindAnyObjectByType<EnemySpawner>();
    }

    // Start is called before the first frame update
    void Start()
    {
        wavesConfig = enemySpawner.GetCurrentWave();
        wayPoints = wavesConfig.GetOtherWayPoints();
        transform.position = wayPoints[wayPointsIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPath(); 
    }

    void FollowPath()
    {
        if(wayPointsIndex < wayPoints.Count)
        {
            Vector3 targetPosition = wayPoints[wayPointsIndex].position;
            float delta = wavesConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if(transform.position == targetPosition)
            {
                wayPointsIndex++;
            }
        }
        else 
        {
            Destroy(gameObject);
        }
    }
}
