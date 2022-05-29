using System;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Bullets bullets;
    [SerializeField]
    private float fireRate;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    public Bullets Bullets { get => bullets; set => bullets = value; }
    public float FireRate { get => fireRate; set => fireRate = value; }

    Coroutine Coroutine { get; set; }
    bool IsPressFire { get; set; } = false;

    private void Start()
    {
        Bullets.Init();
    }

    public void UpgradeWeapon()
    {
        Bullets.SetNextBullet();
    }

    IEnumerator ShootingCorutine()
    {
        while (IsPressFire == true)
        {
            Vector3 mouseWorldPosition = Utils.MouseScreenToWorldPoint();
            Vector3 direction = mouseWorldPosition - transform.position;

            Bullet createdBullet = Instantiate(Bullets.CurrentBullet, transform.position, Quaternion.identity);//todo pooling
            createdBullet.Init(direction);

            yield return new WaitForSeconds(60f / fireRate);
        }
    }

    public void Shoot()
    {
        IsPressFire = true;
        Coroutine = StartCoroutine(ShootingCorutine());
    }

    public void StopShoot()
    {
        IsPressFire = false;
        StopCoroutine(Coroutine);
    }
}
