using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonPersistence<GameManager>
{
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
