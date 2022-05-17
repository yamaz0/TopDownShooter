using UnityEngine;

abstract public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float damage = 1f;

    public float Damage { get => damage; set => damage = value; }

    abstract public void Init(Vector2 direction);
}