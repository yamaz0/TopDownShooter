using UnityEngine;

public class TowerStructure : StructureBase<TowerInfo>
{

    public GameObject Enemy { get; private set; }
    public float CacheTime = 0;

    private void FixedUpdate()
    {
        Rotate();
        TryShoot();
    }

    public void Rotate()
    {
        if (Enemy != null)
        {
            // transform.LookAt(Enemy.Transform.Position);
        }
    }

    public void TryShoot()
    {
        if (Enemy == null)
        {
            //Search Enemy
        }

        if (CacheTime + Info.FireRate > Time.unscaledTime)
        {
            //Shoot
        }
    }
}
