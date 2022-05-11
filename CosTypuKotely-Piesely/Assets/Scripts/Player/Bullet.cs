using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    public void Init(Vector2 direction)
    {
        rb.velocity = direction * 50f;
    }
}
