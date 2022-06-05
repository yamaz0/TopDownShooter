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
    private int magazineSize;
    [SerializeField]
    private bool isUnlocked;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    public Bullets Bullets { get => bullets; set => bullets = value; }
    public float FireRate { get => fireRate; set => fireRate = value; }

    Coroutine Coroutine { get; set; }
    bool IsPressFire { get; set; } = false;
    public bool IsUnlocked { get => isUnlocked; set => isUnlocked = value; }
    public int MagazineSize { get => magazineSize; set => magazineSize = value; }
    public int CurrentMagazineSize { get; private set; }

    public bool IsReloading;

    private void OnEnable()
    {
        if (IsReloading == true)
        {
            //przeladowanie od nowa
        }
    }

    private void OnDisable()
    {
        //jesli przeladowuje to przerwij a przy zmianie broni bedzie od nowa przeladowywac
    }

    private void Start()
    {
        Bullets.Init();
    }

    public void UpgradeWeapon()
    {
        Bullets.SetNextBullet();
    }

    IEnumerator ReloadCorutine()
    {
        yield return new WaitForSeconds(2);
        IsReloading = false;
        CurrentMagazineSize = MagazineSize;
    }

    IEnumerator ShootingCorutine()
    {
        while (IsPressFire == true)
        {
            if (IsReloading == false)//do przerobienia
            {
                Shooting();
            }

            yield return new WaitForSeconds(60f / fireRate);//do optymalizacji
        }
    }

    private void Shooting()
    {
        Vector3 mouseWorldPosition = Utils.MouseScreenToWorldPoint();
        Vector3 direction = mouseWorldPosition - transform.position;

        Bullet createdBullet = Instantiate(Bullets.CurrentBullet, transform.position, Quaternion.identity);//todo pooling
        createdBullet.Init(direction);
        CurrentMagazineSize--;
        if (CurrentMagazineSize <= 0)
        {
            IsReloading = true;
            StartCoroutine(ReloadCorutine());
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
