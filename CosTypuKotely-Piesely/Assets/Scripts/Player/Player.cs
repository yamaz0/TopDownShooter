using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IDamageable
{
    void TakeDamage(float value);
}

public class Player : Singleton<Player>, IDamageable
{
    private const float TO_PERCENTAGE = 0.01f;

    [SerializeField]
    private Movement movement;
    [SerializeField]
    private PlayerWeapons playerShoot;
    [SerializeField]
    private PlayerStats playerStats;
    [SerializeField]
    private PlayerBuild playerBuild;

    public Movement Movement { get => movement; set => movement = value; }
    public PlayerStats PlayerStats { get => playerStats; set => playerStats = value; }
    public PlayerWeapons PlayerShoot { get => playerShoot; set => playerShoot = value; }
    public PlayerBuild PlayerBuild { get => playerBuild; set => playerBuild = value; }

    public void TakeDamage(float value)
    {
        PlayerStats.Hp.AddValue(value);
    }

    protected override void Initialize()
    {
        PlayerShoot.Init();
        PlayerBuild.Init();
    }

    private void FixedUpdate()
    {
        Movement.Move();
    }

    private void Update()
    {
        Rotation.Rotate(transform);
    }

}