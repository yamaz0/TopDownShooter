using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Singleton<Player>
{
    [SerializeField]
    private PlayerInput input;

    [SerializeField]
    private Movement movement;
    [SerializeField]
    private PlayerRotation playerRotation;
    [SerializeField]
    private PlayerShoot playerShoot;
    [SerializeField]
    private PlayerStats playerStats;

    public PlayerInput Input { get => input; }
    public PlayerRotation PlayerRotation { get => playerRotation; set => playerRotation = value; }
    public Movement Movement { get => movement; set => movement = value; }
    public PlayerStats PlayerStats { get => playerStats; set => playerStats = value; }
    public PlayerShoot PlayerShoot { get => playerShoot; set => playerShoot = value; }

    private void Start()
    {
        PlayerShoot.Init();
    }

    private void FixedUpdate()
    {
        Movement.Move();
    }

    private void Update()
    {
        PlayerRotation.Rotate(transform);
    }

    public void Fire(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
            PlayerShoot.Shoot(PlayerRotation.GetShootDirection(transform));
    }

    public void Move(InputAction.CallbackContext callbackContext)
    {
        Movement.SetDirection(callbackContext.ReadValue<Vector2>());
    }

    public void ChangeWeapon(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {

            float v = callbackContext.ReadValue<float>();
            PlayerShoot.ChangeWeapon((int)v - 1);
        }
    }
}