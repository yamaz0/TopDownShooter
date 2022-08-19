using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class GameManager : SingletonPersistence<GameManager>
{
    [SerializeField]
    private PlayerInput input;

    [Inject]
    private InputManager InputManagerInstance { get; set; }
    [Inject]
    private Player PlayerInstance { get; set; }
    [Inject]
    private WaveManager WaveManagerInstance { get; set; }

    private void Start()
    {
        PlayerInstance.PlayerStats.Hp.OnValueChanged += CheckLose;
        StartGame();
    }

    public void StartGame()
    {
        Debug.Log("Start game!");
        PlayerInstance.Init();

        InputManagerInstance.ActionMapSetActiv("CharacterControl", true);
        InputManagerInstance.ActionMapSetActiv("Shop", true);
        InputManagerInstance.ActionMapSetActiv("Shooting", true);

        WaveManagerInstance.StartWave();
    }

    private void OnDisable()
    {
        PlayerInstance.PlayerStats.Hp.OnValueChanged -= CheckLose;
    }

    public void CheckLose(float hp)
    {
        if (hp <= 0)
        {
            Debug.Log("YOU LOSE");
        }
    }
}
