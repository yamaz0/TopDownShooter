using UnityEngine.InputSystem;

public partial class InputManager
{
    public void ChangeNextStructure(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            PlayerInstance.PlayerBuild.SetNextStructureSlot();
        }
    }

    public void ChangePreviousStructure(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            PlayerInstance.PlayerBuild.SetPreviousStructureSlot();
        }
    }

    public void ChangeStructure(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            float v = callbackContext.ReadValue<float>();
            PlayerInstance.PlayerBuild.SetCurrentStructureSlot((int)v);
        }
    }

    public void BuildStructure(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
            PlayerInstance.PlayerBuild.Build();
    }
}
