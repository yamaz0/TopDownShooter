using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public partial class InputManager : SingletonPersistence<InputManager>
{
    [SerializeField]
    private PlayerInput input;

    public PlayerInput Input { get => input; }


    private void SetBuildingMode(bool state)
    {
        ActionMapSetActiv("Building", state);
        ActionMapSetActiv("Shooting", !state);
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