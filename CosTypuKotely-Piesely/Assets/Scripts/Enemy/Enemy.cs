using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Zenject;

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
    private GameObject body;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxSpeed;

    public float Hp { get => hp; set => hp = value; }
    public float Dmg { get => dmg; set => dmg = value; }
    public float Gold { get => gold; set => gold = value; }
    public bool IsAlive { get; private set; }

    public IDamageable Target = null;

    // [Inject]
    // private Player PlayerInstance { get; set; }

    private void Update()
    {
        if (IsAlive == true)
        {
            Vector2 direction = Player.Instance.transform.position - transform.position;
            rb.velocity = direction.normalized * speed * Time.deltaTime;
        }
    }

    public void Init(EnemyInfo info, int strenghtMultiplier = 1)
    {
        Hp = info.Hp * strenghtMultiplier;
        Dmg = info.Dmg * strenghtMultiplier;
        Gold = info.Gold * strenghtMultiplier;
        maxSpeed = info.Speed;
        speed = info.Speed;
        IsAlive = true;
        body.SetActive(true);
    }

    public void TakeDamage(float damage)
    {
        Hp -= damage;

        if (Hp <= 0 && IsAlive == true)
        {
            Die();
        }
    }

    private void Die()
    {
        Player.Instance.PlayerStats.Cash.AddValue(Gold);
        WaveManager.Instance.EnemiesCounter.AddValue(-1);
        IsAlive = false;
        rb.velocity = Vector2.zero;
        body.SetActive(false);
        StartCoroutine(Dissolve());
    }

    private IEnumerator Dissolve()
    {
        float fade = 1;
        while (fade > 0)
        {
            fade -= Time.deltaTime;
            spriteRenderer.material.SetFloat("_Fade", fade);
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
    private IDamageable CheckDamageable(Collider2D other)
    {
        return other.GetComponent<IDamageable>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        CheckDamageable(other)?.TakeDamage(-Dmg);//TODO lepsze odbieranie zycia
    }
}
