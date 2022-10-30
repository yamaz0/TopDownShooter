using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : Singleton<WindowManager>
{
    [SerializeField]
    private GameObject shop;
    [SerializeField]
    private GameObject wheelWeaponsUI;
    [SerializeField]
    private GameObject wheelStructuresUI;
    [SerializeField]
    private DeathUIController DeathUIController;
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private CameraFollow cameraFollow;

    private void SetCharacterControl(bool state)
    {
        InputManager.Instance.ActionMapSetActiv("CharacterControl", state);
        cameraFollow.enabled = state;
    }

    public void ShowCanvas()
    {
        canvas.SetActive(!canvas.activeSelf);
    }

    private void SetCharacterShooting(bool state)
    {
        InputManager.Instance.ActionMapSetActiv("Shooting", state);
        cameraFollow.enabled = state;
    }

    private void SetCharacterBuilding(bool state)
    {
        InputManager.Instance.ActionMapSetActiv("Building", state);
        cameraFollow.enabled = state;
    }

    public void ShowDeathMenu(float endTime)
    {
        DeathUIController.Init(endTime);
    }

    public void ShowShop()
    {
        bool isShopActive = shop.activeSelf;
        SetCharacterControl(isShopActive);
        SetCharacterShooting(isShopActive);
        shop.SetActive(!isShopActive);
    }

    public void ShowWeaponsWheel()
    {
        bool isWheelActive = wheelWeaponsUI.activeSelf;
        SetCharacterControl(isWheelActive);
        SetCharacterShooting(isWheelActive);
        wheelWeaponsUI.SetActive(!isWheelActive);
    }

    public void ShowStructuresWheel()
    {
        bool isWheelActive = wheelStructuresUI.activeSelf;
        SetCharacterControl(isWheelActive);
        SetCharacterBuilding(isWheelActive);
        wheelStructuresUI.SetActive(!isWheelActive);
    }
}
