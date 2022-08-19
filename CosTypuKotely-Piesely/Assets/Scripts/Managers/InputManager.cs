using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class InputManager : SingletonPersistence<InputManager>
{
    [SerializeField]
    private PlayerInput input;

    public PlayerInput Input { get => input; }

    [Inject]
    private Player PlayerInstance { get; set; }
    // private void Start()
    // {
    //     ActionMapSetActiv("WaveBreak", true);
    // }

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

    public void StartWave(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            WaveManager.Instance.StartWave();
        }
    }

    public void ChangeMode(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed && WaveManager.Instance.IsWave == false)
        {
            PlayerBuild playerBuild = PlayerInstance.PlayerBuild;
            playerBuild.ChangeMode();
            bool isBuildMode = playerBuild.IsBuildMode;

            ActionMapSetActiv("Building", isBuildMode);
            ActionMapSetActiv("Shooting", !isBuildMode);
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

    public void ActionMapSetActiv(string name, bool state)
    {
        InputActionMap searchedActionMap = Input.actions.FindActionMap(name);

        if (state == true)
        {
            searchedActionMap.Enable();
        }
        else
        {
            searchedActionMap.Disable();
        }
    }

}