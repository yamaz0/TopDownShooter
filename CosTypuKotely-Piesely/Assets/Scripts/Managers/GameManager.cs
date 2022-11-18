using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class GameplayController
{

    //start map
    //init all 
    // start wave
    public event System.Action OnGameStarted = delegate { };
    public event System.Action OnGameEnd = delegate { };
    // public void StartGame(MapInfo? cos takiego przeslac przy scene load)
    public void StartGame()
    {
        //getMap from mapManager
        //init shop
        //init ui ammo player health weapons and others
        //start waves
    }

}

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

    public float StartTime { get; private set; }

    private void Start()
    {
        PlayerInstance.PlayerStats.Hp.OnValueChanged += CheckLose;
        StartGame();
    }

    public void StartGame()
    {
        Debug.Log("Start game!");
        PlayerInstance.Init();
        LightManager.Instance.Init();

        InputManagerInstance.ActionMapSetActiv("CharacterControl", true);
        InputManagerInstance.ActionMapSetActiv("Shop", true);
        InputManagerInstance.ActionMapSetActiv("Shooting", true);

        WindowManager.Instance.ShowCanvas();

        WaveManagerInstance.Init();
        StartTime = Time.fixedTime;
    }

    private void OnDisable()
    {
        PlayerInstance.PlayerStats.Hp.OnValueChanged -= CheckLose;
    }

    public void CheckLose(float hp)//TODO zrobic z tego klase bo rozne warunki w zaleznosci od trybu np czas albo obrona hq a teraz standardowe takie tylko
    {
        if (hp <= 0)
        {
            PlayerInstance.Deactive();
            float endTime = Time.fixedTime - StartTime;
            WindowManager.Instance.ShowDeathMenu(endTime);
            Debug.Log("YOU LOSE");
        }
    }
}
