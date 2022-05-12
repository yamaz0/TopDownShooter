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

    private void Update()
    {
        Vector2 direction = Player.Instance.transform.position - transform.position;
        rb.velocity = direction.normalized * 300 * Time.deltaTime;
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Player.Instance.PlayerStats.Gold.AddValue(gold);
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player.Instance.PlayerStats.Hp.AddValue(-dmg);
        }
    }
}
