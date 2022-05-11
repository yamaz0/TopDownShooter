using UnityEngine;

[System.Serializable]
public class Movement
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float speed;
    public Vector2 Direction { get; set; }
    public float Speed { get => speed; set => speed = value; }

    public void SetDirection(Vector2 dir)
    {
        Direction = dir;
    }

    public void Move()
    {
        rb.velocity = Direction.normalized * Speed * Time.deltaTime;
    }
}
