using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

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

    public void Init(bool isDay)
    {
        if (isDay == false)
        {
            AttachEvents();
        }
    }

    public void AttachEvents()
    {
        AreaLightSize.OnValueChanged += SetAreaLightSize;
        FlashlightStrenght.OnValueChanged += SetFlashlightStrenght;
        FlashlightLenght.OnValueChanged += SetFlashlightLenght;
    }

    public void DetachEvents()
    {
        AreaLightSize.OnValueChanged -= SetAreaLightSize;
        FlashlightStrenght.OnValueChanged -= SetFlashlightStrenght;
        FlashlightLenght.OnValueChanged -= SetFlashlightLenght;
    }

    public Float GetStat(string statName)
    {
        return statName switch
        {
            "AreaLightSize" => AreaLightSize,
            "FlashlightStrenght" => FlashlightStrenght,
            "FlashlightLenght" => FlashlightLenght,
            _ => null
        };
    }
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
