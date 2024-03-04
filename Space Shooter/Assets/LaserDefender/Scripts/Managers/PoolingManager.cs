using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    private static PoolingManager instance;
    public static PoolingManager Instance { get { return instance; } }

    [SerializeField] GameObject playerLaserPrefab;
    [SerializeField] GameObject enemyLaserPrefab;
    [SerializeField] int bulletAmount = 20;

    List<GameObject> playerLasersList;
    List<GameObject> enemyLasersList;

    private void Awake()
    {
        instance = this;

        playerLasersList = new List<GameObject>(bulletAmount);
        enemyLasersList = new List<GameObject>(bulletAmount);

        SpawnInitialObjects(playerLaserPrefab, playerLasersList);
        SpawnInitialObjects(enemyLaserPrefab, enemyLasersList);
    }

    public GameObject GetPlayerLaser()
    {
        return GetObject(playerLaserPrefab, playerLasersList);
    }

    public GameObject GetEnemyLaser()
    {
        return GetObject(enemyLaserPrefab, enemyLasersList);
    }

    private void SpawnInitialObjects(GameObject prefab, List<GameObject> list)
    {
        for (int i = 0; i < bulletAmount; i++)
        {
            GameObject prefabInstance = Instantiate(prefab);
            prefabInstance.transform.SetParent(transform);
            prefabInstance.SetActive(false);

            list.Add(prefabInstance);
        }
    }

    private GameObject GetObject(GameObject prefab, List<GameObject> list)
    {
        foreach (GameObject obj in list)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newPrefabInstance = Instantiate(prefab);
        newPrefabInstance.SetActive(transform);
        list.Add(newPrefabInstance);

        return newPrefabInstance;
    }
}
