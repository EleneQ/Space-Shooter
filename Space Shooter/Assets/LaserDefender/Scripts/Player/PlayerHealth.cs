using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 300;
    [SerializeField] new PlayAudio audio;

    [SerializeField] Hearts hearts;

    [Header("Damage Effect")]
    [SerializeField] SpriteRenderer rend;
    [SerializeField] float damageEffectDuration = 1f;
    [SerializeField] Color damageColor;
    Color startingColor;

    private void Start()
    {
        startingColor = rend.color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyLaser") ||
            other.CompareTag("Enemy"))
        {
            ProcessHit();
            StartCoroutine(DamageEffect());
        }
    }

    private void ProcessHit()
    {
        health--;
        hearts.DecreaseHealth(health);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        LevelManager.instance.LoadGameOver();
        audio.PlayDeathSound();
    }

    public int GetHealth()
    {
        return health;
    }

    private IEnumerator DamageEffect()
    {
        rend.color = damageColor;

        yield return new WaitForSeconds(damageEffectDuration);
        rend.color = startingColor;
    }
}
