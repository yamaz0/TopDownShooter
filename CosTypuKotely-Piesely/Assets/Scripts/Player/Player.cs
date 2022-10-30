using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

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
    private PlayerWeapons playerWeapons;
    [SerializeField]
    private PlayerStats playerStats;
    [SerializeField]
    private PlayerBuild playerBuild;
    [SerializeField]
    private PlayerLight playerLight;

    public Movement Movement { get => movement; set => movement = value; }
    public PlayerStats PlayerStats { get => playerStats; set => playerStats = value; }
    public PlayerWeapons PlayerWeapons { get => playerWeapons; set => playerWeapons = value; }
    public PlayerBuild PlayerBuild { get => playerBuild; set => playerBuild = value; }

    [Inject]
    MapManager MapManagerInstance { get; set; }
    public PlayerLight PlayerLight { get => playerLight; set => playerLight = value; }

    public void TakeDamage(float value)
    {
        PlayerStats.Hp.AddValue(value);
    }

    public void Init()//TODO zmienic na initializacje przy wczytaniu mapy
    {
        gameObject.SetActive(true);
        List<int> startWeaponsID = MapManagerInstance.Options.StartWeaponsID;
        List<int> startStructuresID = MapManagerInstance.Options.StartStructuresID;
        PlayerWeapons.Init(startWeaponsID);
        PlayerBuild.Init(startStructuresID);//TODO takie samo jak z weapons czyli startowe dostepne budynki
    }

    public void Deactive()
    {
        gameObject.SetActive(false);
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