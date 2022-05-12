using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[System.Serializable]
public class PlayerStats
{
    [SerializeField]
    private Float hp = new Float(50);
    [SerializeField]
    private Float maxHp = new Float(100);
    [SerializeField]
    private Float armor = new Float(0);
    [SerializeField]
    private Float speed = new Float(500);
    [SerializeField]
    private Float gold = new Float(0);

    public Float Hp { get => hp; set => hp = value; }
    public Float MaxHp { get => maxHp; set => maxHp = value; }
    public Float Armor { get => armor; set => armor = value; }
    public Float Speed { get => speed; set => speed = value; }
    public Float Gold { get => gold; set => gold = value; }
}

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
    public Movement Movement { get => movement; set => movement = value; }
    public PlayerStats PlayerStats { get => playerStats; set => playerStats = value; }

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
        playerShoot.Shoot(playerRotation.GetShootDirection(transform));
    }

    public void Move(InputAction.CallbackContext callbackContext)
    {
        Movement.SetDirection(callbackContext.ReadValue<Vector2>());
    }
}