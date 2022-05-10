using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[System.Serializable]
public class Movement
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float speed;
    public Vector2 Direction { get; set; }
    public float Speed { get => speed; set => speed = value; }

    public void SetDirection(Vector2 dir)
    {
        Direction = dir;
    }

    public void Move()
    {
        rb.velocity = Direction.normalized * Speed * Time.deltaTime;
    }
}

public class Player : Singleton<Player>
{
    [SerializeField]
    private Float hp;

    [SerializeField]
    private PlayerInput input;

    [SerializeField]
    private Movement movement;


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


    public void Move(InputAction.CallbackContext callbackContext)
    {
        Movement.SetDirection(callbackContext.ReadValue<Vector2>());
    }
}