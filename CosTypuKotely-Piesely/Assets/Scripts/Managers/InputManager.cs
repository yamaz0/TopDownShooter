using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : SingletonPersistence<InputManager>
{
    [SerializeField]
    private PlayerInput input;

    public PlayerInput Input { get => input; }

    // private void Start()
    // {
    //     ActionMapSetActiv("WaveBreak", true);
    // }

    public void Fire(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            Player.Instance.PlayerWeapons.Shoot();
        }
        else if (callbackContext.canceled)
        {
            Player.Instance.PlayerWeapons.StopShoot();
        }
    }

    public void Move(InputAction.CallbackContext callbackContext)
    {
        Player.Instance.Movement.SetDirection(callbackContext.ReadValue<Vector2>());
    }

    public void ChangeWeapon(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            float v = callbackContext.ReadValue<float>();
            Player.Instance.PlayerWeapons.ChangeWeapon((int)v);
        }
    }

    public void ReloadWeapon(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            Player.Instance.PlayerWeapons.CurrentWeapon.Reload();
        }
    }

    public void ChangeNextWeapon(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            Player.Instance.PlayerWeapons.WeaponsSelector.NextSlot();
        }
    }

    public void ChangePreviousWeapon(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            Player.Instance.PlayerWeapons.WeaponsSelector.PreviousSlot();
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
            PlayerBuild playerBuild = Player.Instance.PlayerBuild;
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
            Player.Instance.PlayerBuild.SetCurrentStructureId((int)v);
        }
    }

    public void BuildStructure(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
            Player.Instance.PlayerBuild.Build();
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