using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public partial class InputManager
{
    public void StartWave(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            WaveManager.Instance.StartWave();
        }
    }
}