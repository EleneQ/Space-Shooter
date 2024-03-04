using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] Transform laserSpawnPoint;
    [SerializeField] float laserFirePeriod = 0.1f;
    Coroutine shootingCoroutine;

    [SerializeField] new PlayAudio audio;
 
    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
       if(Input.GetKeyDown(KeyCode.Space))
       {
            shootingCoroutine = StartCoroutine(nameof(ShootContinuously));
       }
       else if (Input.GetKeyUp(KeyCode.Space))
       {
            StopCoroutine(shootingCoroutine);
       }
    }

    IEnumerator ShootContinuously()
    {
        while(true)
        {
            SpawnLaser();
            audio.PlayShootingSound();

            yield return new WaitForSeconds(laserFirePeriod);
        }
    }

    private void SpawnLaser()
    {
        GameObject laser = PoolingManager.Instance.GetPlayerLaser();
        laser.transform.position = laserSpawnPoint.position;
        laser.transform.rotation = Quaternion.identity;
    }
}
