using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float speed = 15f;
    [SerializeField]
    private float damage = 1f;

    public void Init(Vector2 direction)
    {
        rb.velocity = direction.normalized * speed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
