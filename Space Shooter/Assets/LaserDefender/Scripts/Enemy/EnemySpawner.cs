using UnityEngine;
using System.Collections.Generic;
using System.Collections;

#region Explanation
//this script will handle: 1.order of waves, 2.spawning each wave, 3.spawning each enemy in the wave.
#endregion
public class EnemySpawner : MonoBehaviour 
{
    [SerializeField] List<WaveConfig> waveConfigsList;
    int startingWaveIndex = 0;

    [SerializeField] bool looping = false;

    #region Explanation
    //When you use StartCoroutine(SpawnAllEnemiesInWave(currentWave)) without yield return, the method calling this
    //line will continue executing immediately without waiting for the SpawnAllEnemiesInWave coroutine to finish. In
    //other words, it will not wait for all the enemies to spawn in the current wave before moving on to the next wave
    #endregion
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves()); 
        }
        while (looping);
    }

    #region Explanation
    //when an enemy gets spawned it asks "what wave am I a part of", which is what we're specifyng in the (). that
    //has to be done because, in the waveconfig, we specify the path it should move along, it's speed and so on.
    #endregion
    IEnumerator SpawnAllWaves()
    {
        for(int currentWaveIndex = startingWaveIndex; currentWaveIndex < waveConfigsList.Count; currentWaveIndex++)
        {
            #region Explanation
            //wave at a certain index, which is being fed into spawnallenemiesinwave and subsequently to the enemypathing
            //script through here (from the inspector).
            #endregion
            var currentWave = waveConfigsList[currentWaveIndex];
            #region Explanation
            //So that a new wave spawns once the old one has finished spawning.
            #endregion
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave)); 
        }
    }

    IEnumerator SpawnAllEnemiesInWave(WaveConfig wave)
    {
        for(int enemyCount = 0; enemyCount < wave.GetNumberOfEnemiesToSpawn(); enemyCount++)
        {
            var newEnemy = Instantiate(wave.GetEnemyPrefab(), wave.GetWaypoints()[0].transform.position, 
                                                              wave.GetWaypoints()[0].transform.rotation);
            #region Explanation
            //feeding in the current wave to the enemypathing script.
            #endregion
            newEnemy.GetComponent<EnemyPathFollow>().SetWaveConfig(wave); 

            yield return new WaitForSeconds(wave.GetTimeBetweenEnemySpawns());
        }      
    }
}