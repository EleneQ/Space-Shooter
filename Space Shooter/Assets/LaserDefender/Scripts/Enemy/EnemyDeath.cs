using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] new PlayAudio audio;

    [Header("Explosion")]
    [SerializeField] GameObject explosionParticlesPrefab;
    [SerializeField] float durationOfExplosion = 1f;

    bool isAlive = true;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerLaser") ||
            other.CompareTag("Player"))
        {
            Die();
        }
    }

    private void Die()
    {
        if (isAlive)
        {
            isAlive = false;
            ScoreManager.instance.AddScore();

            GameObject explosionObj = Instantiate(explosionParticlesPrefab, transform.position, transform.rotation);
            Destroy(explosionObj, durationOfExplosion);

            audio.PlayDeathSound();
            Destroy(gameObject);
        }
    }
}
