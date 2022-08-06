using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Bullets
{
    [SerializeField]
    private List<Bullet> bullets = new List<Bullet>();
    [SerializeField]
    private int amountToPool;

    public int CurrentWeaponLevel { get; private set; } = 0;
    public Bullet CurrentBullet { get; private set; }

    private List<Bullet> PooledBullets { get; set; }

    public void Init(WeaponInfo info)
    {
        bullets.AddRange(info.Bullets);
        CurrentBullet = bullets[0];
        PooledBullets = new List<Bullet>();

        SetPoolObjects();
    }

    private void SetPoolObjects()
    {
        for (int i = PooledBullets.Count - 1; i >= 0; i--)
        {
            GameObject.Destroy(PooledBullets[i].gameObject);
        }

        PooledBullets.Clear();

        for (int i = 0; i < amountToPool; i++)
        {
            Bullet bullet = GameObject.Instantiate(CurrentBullet);
            bullet.gameObject.SetActive(false);
            PooledBullets.Add(bullet);
        }
    }

    public Bullet GetNextBullet()
    {
        return CurrentWeaponLevel + 1 < bullets.Count ? bullets[CurrentWeaponLevel + 1] : null;
    }

    public void SetNextBullet()
    {
        CurrentWeaponLevel++;
        CurrentBullet = bullets[CurrentWeaponLevel];
        SetPoolObjects();
    }

    public Bullet GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (PooledBullets[i].isActiveAndEnabled == false)
            {
                return PooledBullets[i];
            }
        }
        return null;
    }

    public void Fire(Vector3 direction, Transform transform)
    {
        Bullet pooledBullet = GetPooledObject();
        pooledBullet.transform.position = transform.position;
        pooledBullet.gameObject.SetActive(true);
        pooledBullet.Init(direction);
    }
}
