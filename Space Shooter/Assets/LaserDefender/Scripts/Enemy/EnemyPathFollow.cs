using System.Collections.Generic;
using UnityEngine;

public class EnemyPathFollow : MonoBehaviour
{
    List<Transform> wayPoints;
    #region Explanation
    //the waypoint the enemy's currently working towards.
    #endregion
    int nextWayPointIndex = 0; 

    WaveConfig waveConfig;

    #region Explanation
    //the waves are now passed in through the enemyspawner script (now we can reference the waves only in the enmeyspawner),
    //so we'll only have to drag in the waves there
    #endregion
    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void Start()
    {
        wayPoints = waveConfig.GetWaypoints();

        transform.position = wayPoints[nextWayPointIndex].position;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (nextWayPointIndex <= wayPoints.Count - 1) 
        {
            var currentPos = transform.position;
            var targetPos = wayPoints[nextWayPointIndex].position;
            var movementPerFrame = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;
            
            transform.position = Vector2.MoveTowards(currentPos, targetPos, movementPerFrame);

            if (transform.position == targetPos)
            {
                nextWayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}