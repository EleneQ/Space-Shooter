using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] new PlayAudio audio;

    float shotTimer;
    [SerializeField] Transform laserSpawnPoint;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 2.5f;
    [SerializeField] GameObject enemyLaser;

    private void Start()
    {
        shotTimer = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    private void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotTimer -= Time.deltaTime;
        if(shotTimer <= 0f)
        {
            Shoot();
            shotTimer = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    void Shoot()
    {
        GameObject enemyLaser = PoolingManager.Instance.GetEnemyLaser();
        enemyLaser.transform.position = transform.position;
        enemyLaser.transform.rotation = Quaternion.identity;

        audio.PlayShootingSound();
    }
}