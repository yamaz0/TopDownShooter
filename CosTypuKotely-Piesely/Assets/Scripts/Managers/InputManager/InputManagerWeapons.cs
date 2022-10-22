using UnityEngine.InputSystem;

public partial class InputManager
{
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
            PlayerInstance.PlayerWeapons.NextWeapon();
        }
    }

    public void ChangePreviousWeapon(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            PlayerInstance.PlayerWeapons.PreviousWeapon();
        }
    }

}
