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

    private void SetCharacterMovement(bool state)
    {
        InputManager.Instance.ActionMapSetActiv("CharacterControl", state);
        cameraFollow.enabled = state;
    }

    public void ShowShop()
    {
        SetCharacterMovement(shop.activeSelf);
        shop.SetActive(!shop.activeSelf);
    }
    public void ShowWeaponsWheel()
    {
        wheelWeaponsUI.SetActive(!wheelWeaponsUI.activeSelf);
    }
}
