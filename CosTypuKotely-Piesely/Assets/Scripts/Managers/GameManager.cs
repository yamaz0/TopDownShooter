using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : SingletonPersistence<GameManager>
{
    [SerializeField]
    private bool isWaveTime = false;
    [SerializeField]
    private PlayerInput input;

    public bool IsWaveTime { get => isWaveTime; set => isWaveTime = value; }

    public void ChangeWaveState()
    {
        isWaveTime = !isWaveTime;
        if (isWaveTime)
            input.actions.FindActionMap("PlayerState").Disable();
        else
            input.actions.FindActionMap("PlayerState").Enable();
    }

    private void Start()
    {
        Player.Instance.PlayerStats.Hp.OnValueChanged += CheckLose;
    }

    private void OnDisable()
    {
        Player.Instance.PlayerStats.Hp.OnValueChanged -= CheckLose;
    }

    public void CheckLose(float hp)
    {
        if (hp <= 0)
        {
            Debug.Log("YOU LOSE");
        }
    }
}
