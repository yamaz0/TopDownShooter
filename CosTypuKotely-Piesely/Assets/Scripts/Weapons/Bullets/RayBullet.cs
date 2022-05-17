using UnityEngine;

public class RayBullet : Bullet
{
    [SerializeField]
    private TrailRenderer trailRenderer;
    [SerializeField]
    private ContactFilter2D filtr;

    public override void Init(Vector2 direction)
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, direction.normalized, 15, filtr.layerMask);
        Vector2 origin = new Vector2(transform.position.x, transform.position.y);
        Vector2 endpos = origin + direction.normalized * 15;

        trailRenderer.AddPosition(origin);

        if (raycastHit2D.collider != null && raycastHit2D.collider.tag == "Enemy")
        {
            endpos = raycastHit2D.collider.transform.position;
            raycastHit2D.collider.GetComponent<Enemy>().TakeDamage(1);
        }
        trailRenderer.transform.position = endpos;
        Destroy(gameObject, 0.1f);//tymczasowo
    }
}