using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : SingletonPersistence<GameManager>
{
    [SerializeField]
    private PlayerInput input;

    private void Start()
    {
        Player.Instance.PlayerStats.Hp.OnValueChanged += CheckLose;
        StartGame();
    }

    public void StartGame()
    {
        Debug.Log("Start game!");

        InputManager.Instance.ActionMapSetActiv("CharacterControl", true);
        InputManager.Instance.ActionMapSetActiv("Shop", true);
        InputManager.Instance.ActionMapSetActiv("Shooting", true);

        WaveManager.Instance.StartWave();
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
