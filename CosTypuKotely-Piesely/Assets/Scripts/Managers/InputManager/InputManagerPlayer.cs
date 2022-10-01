using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public partial class InputManager
{
    [Inject]
    private Player PlayerInstance { get; set; }

    public void Fire(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            PlayerInstance.PlayerWeapons.Shoot();
        }
        else if (callbackContext.canceled)
        {
            PlayerInstance.PlayerWeapons.StopShoot();
        }
    }

    public void Move(InputAction.CallbackContext callbackContext)
    {
        PlayerInstance.Movement.SetDirection(callbackContext.ReadValue<Vector2>());
    }

    public void ChangeWeapon(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            float v = callbackContext.ReadValue<float>();
            PlayerInstance.PlayerWeapons.ChangeWeapon((int)v);
        }
    }

    public void ReloadWeapon(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            PlayerInstance.PlayerWeapons.CurrentWeapon.Reload();
        }
    }

    public void ChangeNextWeapon(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            PlayerInstance.PlayerWeapons.WeaponsSelector.NextSlot();
        }
    }

    public void ChangePreviousWeapon(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            PlayerInstance.PlayerWeapons.WeaponsSelector.PreviousSlot();
        }
    }
    public void ChangeMode(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed && WaveManager.Instance.IsWave == false)
        {
            PlayerBuild playerBuild = PlayerInstance.PlayerBuild;
            PlayerInstance.PlayerBuild.ChangeMode();
            SetBuildingMode(playerBuild.IsBuildMode);
        }
    }

    public void ChangeStructure(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            float v = callbackContext.ReadValue<float>();
            PlayerInstance.PlayerBuild.SetCurrentStructureId((int)v);
        }
    }

    public void BuildStructure(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
            PlayerInstance.PlayerBuild.Build();
    }
}