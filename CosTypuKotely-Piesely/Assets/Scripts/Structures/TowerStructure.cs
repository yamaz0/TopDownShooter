using System.Collections;
using UnityEngine;

public class TowerStructure : StructureBase
{
    public Enemy Enemy { get; private set; }
    WaitForSeconds rotateWaitTime = new WaitForSeconds(.1f);
    [SerializeField]
    private LayerMask mask;
    [SerializeField]
    private LineRenderer lineRenderer;

    public float CacheTime { get; private set; }
    public LineRenderer LineRenderer { get => lineRenderer; set => lineRenderer = value; }

    private void FixedUpdate()
    {
        // Rotate();
        TryShoot();
    }

    public void Rotate()
    {
        if (Enemy == null)
        {
            return;
        }

        Rotation.QuaternionSlerp(transform, Enemy.transform, 0.1f);
    }

    public void TryShoot()
    {
        //Search Enemy
        SearchEnemy();

        if (Enemy == null)
        {
            return;
        }

        if (CacheTime + ((TowerInfo)Info).FireRate <= Time.unscaledTime)
        {
            //Shoot
            CacheTime = Time.unscaledTime;

            Vector2 origin = new Vector2(transform.position.x, transform.position.y);
            Vector2 endpos = new Vector2(Enemy.transform.position.x, Enemy.transform.position.y);

            lineRenderer.SetPosition(0, origin);

            Enemy.TakeDamage(((TowerInfo)Info).Dmg);

            lineRenderer.SetPosition(1, endpos);
            StartCoroutine(FadeLineRenderer());
        }
    }

    public IEnumerator FadeLineRenderer()
    {
        Gradient lineRendererGradient = new Gradient();
        float fadeSpeed = 3f;
        float timeElapsed = 0f;
        float alpha = 1f;

        while (timeElapsed < fadeSpeed)
        {
            alpha = Mathf.Lerp(1f, 0f, timeElapsed / fadeSpeed);

            lineRendererGradient.SetKeys
            (
                lineRenderer.colorGradient.colorKeys,
                new GradientAlphaKey[] { new GradientAlphaKey(alpha, 1f) }
            );
            lineRenderer.colorGradient = lineRendererGradient;

            timeElapsed += Time.deltaTime;
            yield return null;
        }

    }

    private void SearchEnemy()
    {
        Collider2D hitinfo = Physics2D.OverlapCircle(transform.position, ((TowerInfo)Info).Range, mask);
        Enemy = hitinfo?.gameObject.GetComponentInParent<Enemy>();
    }

}
