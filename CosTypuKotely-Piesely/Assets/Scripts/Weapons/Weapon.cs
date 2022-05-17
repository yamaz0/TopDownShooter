using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Bullet bullet;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    public void Shoot(Vector2 direction)
    {
        Bullet createdBullet = Instantiate(bullet, transform.position, Quaternion.identity);//todo pooling
        createdBullet.Init(direction);
    }
}
