using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float hp;
    [SerializeField]
    private float dmg;
    [SerializeField]
    private float gold;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxSpeed;

    public float Hp { get => hp; set => hp = value; }
    public float Dmg { get => dmg; set => dmg = value; }
    public float Gold { get => gold; set => gold = value; }

    public IDamageable Target = null;

    private void Update()
    {
        Vector2 direction = Player.Instance.transform.position - transform.position;
        rb.velocity = direction.normalized * speed * Time.deltaTime;
    }

    public void Init(int strenghtMultiplier)
    {
        Hp *= strenghtMultiplier;
        Dmg *= strenghtMultiplier;
        Gold *= strenghtMultiplier;
        speed = maxSpeed;
    }

    public void TakeDamage(float damage)
    {
        Hp -= damage;

        if (Hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Player.Instance.PlayerStats.Gold.AddValue(Gold);
        WaveManager.Instance.EnemiesCounter.AddValue(1);
        Destroy(gameObject);
    }

    private IDamageable CheckDamageable(Collider2D other)
    {
        return other.GetComponent<IDamageable>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        CheckDamageable(other)?.TakeDamage(-Dmg);
    }
}
