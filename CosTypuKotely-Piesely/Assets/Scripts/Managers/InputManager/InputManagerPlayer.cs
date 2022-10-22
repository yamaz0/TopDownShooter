using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
public partial class InputManager
{
    [Inject]
    private Player PlayerInstance { get; set; }

    public void Move(InputAction.CallbackContext callbackContext)
    {
        PlayerInstance.Movement.SetDirection(callbackContext.ReadValue<Vector2>());
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
}