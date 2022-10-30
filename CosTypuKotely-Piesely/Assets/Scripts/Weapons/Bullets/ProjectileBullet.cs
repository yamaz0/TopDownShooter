using UnityEngine;
using System;
using System.Collections;

public class ProjectileBullet : Bullet
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private GameObject puffEffect;
    [SerializeField]
    private TrailRenderer trailRenderer;
    [SerializeField]
    private float speed = 15f;
    Coroutine coroutine;

    public override void Init(Vector2 direction)
    {
        trailRenderer.Clear();
        rb.velocity = direction.normalized * speed;
        coroutine = StartCoroutine(DestroyCouritune());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponentInParent<Enemy>().TakeDamage(Damage);
            StopCoroutine(coroutine);
            Instantiate(puffEffect, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
