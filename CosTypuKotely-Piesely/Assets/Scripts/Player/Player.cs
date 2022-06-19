using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Singleton<Player>
{
    private const float TO_PERCENTAGE = 0.01f;

    [SerializeField]
    private Movement movement;
    [SerializeField]
    private PlayerShoot playerShoot;
    [SerializeField]
    private PlayerStats playerStats;
    [SerializeField]
    private PlayerBuild playerBuild;

    public Movement Movement { get => movement; set => movement = value; }
    public PlayerStats PlayerStats { get => playerStats; set => playerStats = value; }
    public PlayerShoot PlayerShoot { get => playerShoot; set => playerShoot = value; }
    public PlayerBuild PlayerBuild { get => playerBuild; set => playerBuild = value; }

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