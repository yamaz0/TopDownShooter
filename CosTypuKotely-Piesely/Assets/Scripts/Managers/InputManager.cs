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
            Player.Instance.PlayerShoot.Shoot();
        }
        else if (callbackContext.canceled)
        {
            Player.Instance.PlayerShoot.StopShoot();
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
            Player.Instance.PlayerShoot.ChangeWeapon((int)v - 1);//do zmiany bo 0 wtedy jest ujemne
        }
    }

    public void ChangeMode(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed && GameManager.Instance.IsWaveTime == false)
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
            Debug.Log(v);
            Player.Instance.PlayerBuild.SetCurrentStructureId((int)v - 1);//do zmiany bo 0 wtedy jest ujemne
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