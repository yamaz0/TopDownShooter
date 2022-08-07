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
    private CameraFollow cameraFollow;

    private void SetCharacterControl(bool state)
    {
        InputManager.Instance.ActionMapSetActiv("CharacterControl", state);
        cameraFollow.enabled = state;
    }

    private void SetCharacterShooting(bool state)
    {
        InputManager.Instance.ActionMapSetActiv("Shooting", state);
        cameraFollow.enabled = state;
    }

    public void ShowShop()
    {
        SetCharacterControl(shop.activeSelf);
        SetCharacterShooting(shop.activeSelf);
        shop.SetActive(!shop.activeSelf);
    }
    public void ShowWeaponsWheel()
    {
        wheelWeaponsUI.SetActive(!wheelWeaponsUI.activeSelf);
    }
}
