using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    private void Update()
    {
        Vector2 direction = Player.Instance.transform.position - transform.position;

        rb.velocity = direction.normalized * 300 * Time.deltaTime;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player.Instance.Hp.AddValue(-1);
        }
    }
}
