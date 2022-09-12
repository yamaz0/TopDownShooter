using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.InputSystem;
using Zenject;

public interface IDamageable
{
    void TakeDamage(float value);
}

[System.Serializable]
public class PlayerLight
{
    [SerializeField]
    private Float areaLightSize = new Float(2);
    [SerializeField]
    private Float flashlightStrenght = new Float(3);
    [SerializeField]
    private Float flashlightLenght = new Float(7);
    [SerializeField]
    private Light2D areaLightascr;
    [SerializeField]
    private Light2D flashlightscr;

    public Float AreaLightSize { get => areaLightSize; set => areaLightSize = value; }
    public Float FlashlightStrenght { get => flashlightStrenght; set => flashlightStrenght = value; }
    public Float FlashlightLenght { get => flashlightLenght; set => flashlightLenght = value; }

    public void SetPlayerLightAccesories(bool state)
    {
        SetActiveFlashlight(state);
        SetActiveAreaLight(state);
    }

    public void SetActiveFlashlight(bool state)
    {
        flashlightscr.enabled = state;
    }

    public void SetActiveAreaLight(bool state)
    {
        areaLightascr.enabled = state;
    }

    public void SetFlashlightLenght(float value)
    {
        flashlightscr.pointLightOuterRadius = value;
    }

    public void SetFlashlightStrenght(float value)
    {
        flashlightscr.pointLightInnerRadius = value;
    }

    public void SetAreaLightSize(float value)
    {
        areaLightascr.pointLightOuterRadius = value;
    }
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
        List<int> startWeaponsID = MapManagerInstance.Options.StartWeaponsID;
        PlayerWeapons.Init(startWeaponsID);
        PlayerBuild.Init();//TODO takie samo jak z weapons czyli startowe dostepne budynki
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