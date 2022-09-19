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
    private Shooting leftHand;
    [SerializeField]
    private Shooting rightHand;
    [SerializeField]
    private WeaponInfo info;

    public Bullets Bullets { get => bullets; set => bullets = value; }
    public float FireRate { get => fireRate; set => fireRate = value; }
    public bool IsUnlocked { get => isUnlocked; set => isUnlocked = value; }

    Coroutine Coroutine { get; set; }
    bool IsPressFire { get; set; }
    public Magazine Magazine { get => magazine; set => magazine = value; }
    public WeaponInfo Info { get => info; set => info = value; }

    private void OnEnable()
    {
        if (Magazine.IsReloading == true)
        {
            //przeladowanie od nowa
            Reload();
        }
    }

    public void Reload()
    {
        if (Magazine.CanReload() == true)
            StartCoroutine(Magazine.ReloadCorutine());
    }

    public void Init(WeaponInfo inf)
    {
        Bullets.Init(inf);
        Magazine.Init(inf);
        FireRate = inf.FireRate;
        // spriteRenderer.sprite = inf.Icon;
        Info = inf;
    }

    public void UpgradeWeapon()
    {
        Bullets.SetNextBullet();
    }

    public void UnlockWeapon()
    {
        IsUnlocked = true;
    }

    IEnumerator ShootingCorutine()
    {
        bool left = true;
        bool dualShoot = Player.Instance.PlayerStats.DualShoot;

        while (IsPressFire == true)
        {
            if (Magazine.IsReloading == false)//do przerobienia
            {
                Vector3 mouseWorldPosition = Utils.MouseScreenToWorldPoint();
                Vector3 direction = mouseWorldPosition - transform.position;

                if (dualShoot == true)
                {
                    Fire(leftHand, direction);
                    Fire(rightHand, direction);
                }
                else
                {
                    if (left)
                        Fire(leftHand, direction);
                    else
                        Fire(rightHand, direction);
                    left = !left;
                }

                SubtractMagazineAmmo();
            }

            yield return new WaitForSeconds(60f / fireRate);//do optymalizacji
        }
    }

    private void Fire(Shooting shooting, Vector3 direction)
    {
        shooting.StartEffect();
        Bullets.Fire(direction, shooting.TransformObject);
    }

    private void SubtractMagazineAmmo()
    {
        Magazine.AddAmmo(-1);
        bool needReload = Magazine.CheckMagazine();

        if (needReload == true)
        {
            Reload();
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
        if (Coroutine != null)
            StopCoroutine(Coroutine);
    }
}
