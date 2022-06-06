using System;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Bullets bullets;
    [SerializeField]
    private Magazine magazine;
    [SerializeField]
    private float fireRate;
    [SerializeField]
    private bool isUnlocked;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    public Bullets Bullets { get => bullets; set => bullets = value; }
    public float FireRate { get => fireRate; set => fireRate = value; }
    public bool IsUnlocked { get => isUnlocked; set => isUnlocked = value; }

    Coroutine Coroutine { get; set; }
    bool IsPressFire { get; set; }
    public Magazine Magazine { get => magazine; set => magazine = value; }

    private void OnEnable()
    {
        if (Magazine.IsReloading == true)
        {
            //przeladowanie od nowa
            StartCoroutine(Magazine.ReloadCorutine());
        }
    }

    private void Start()
    {
        Bullets.Init();
        Magazine.Init();
    }

    public void UpgradeWeapon()
    {
        Bullets.SetNextBullet();
    }

    IEnumerator ShootingCorutine()
    {
        while (IsPressFire == true)
        {
            if (Magazine.IsReloading == false)//do przerobienia
            {
                Vector3 mouseWorldPosition = Utils.MouseScreenToWorldPoint();
                Vector3 direction = mouseWorldPosition - transform.position;

                Bullets.Fire(direction, transform);
                SubtractMagazineAmmo();
            }

            yield return new WaitForSeconds(60f / fireRate);//do optymalizacji
        }
    }

    private void SubtractMagazineAmmo()
    {
        Magazine.AddAmmo(-1);
        bool isReloading = Magazine.CheckMagazine();

        if (isReloading == true)
        {
            StartCoroutine(Magazine.ReloadCorutine());
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
