using UnityEngine;

public class ProjectileBullet : Bullet
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float speed = 15f;
    public override void Init(Vector2 direction)
    {
        rb.velocity = direction.normalized * speed;
        Destroy(gameObject, 2);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
}
