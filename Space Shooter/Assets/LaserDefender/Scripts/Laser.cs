using UnityEngine;

public class Laser : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float laserSpeed = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(0, laserSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Shredder") ||
           collision.collider.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }
}
