using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Enemy Wave SO")]
public class WaveConfig : ScriptableObject 
{
    [Header("Data shared by the waves")]
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenEnemySpawns = 0.5f;
    [SerializeField] int numberOfEnemiesToSpawn = 5;
    [SerializeField] float enemyMoveSpeed = 2f;

    public GameObject GetEnemyPrefab() { return enemyPrefab; }

    public List<Transform> GetWaypoints()
    {
        var waveWayPoints = new List<Transform>();
        #region Explanation
        //the enemypathing script will access the waypoints from here so that we don't have to drag in the waypoints in the
        //inspector everytime we create a new enemy. this will return the children of a path prefab.
        #endregion
        foreach (Transform child in pathPrefab.transform)
        {
            waveWayPoints.Add(child);
        }

        return waveWayPoints;
    }

    public float GetTimeBetweenEnemySpawns() { return timeBetweenEnemySpawns; }

    public int GetNumberOfEnemiesToSpawn() { return numberOfEnemiesToSpawn; }

    public float GetEnemyMoveSpeed() { return enemyMoveSpeed; }
}