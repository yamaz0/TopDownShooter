using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Singleton<Player>
{
    [SerializeField]
    private Float hp;

    [SerializeField]
    private PlayerInput input;

    [SerializeField]
    private Movement movement;
    [SerializeField]
    private PlayerRotation playerRotation;
    [SerializeField]
    private PlayerShoot playerShoot;

    public Float Hp { get => hp; set => hp = value; }
    public PlayerInput Input { get => input; }
    public Movement Movement { get => movement; set => movement = value; }


    public void Init(float healthPoints = 100)
    {
        Hp.SetValue(healthPoints);
    }

    private void FixedUpdate()
    {
        Movement.Move();
    }

    private void Update()
    {
        playerRotation.Rotate(transform);
    }

    public void Fire(InputAction.CallbackContext callbackContext)
    {
        playerShoot.Shoot(playerRotation.GetShootDirection(transform).normalized);


    }

    public void Move(InputAction.CallbackContext callbackContext)
    {
        Movement.SetDirection(callbackContext.ReadValue<Vector2>());
    }
}