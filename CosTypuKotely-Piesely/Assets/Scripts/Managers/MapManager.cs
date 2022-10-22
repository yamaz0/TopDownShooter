using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WinCodition { Time, BaseDefend, Survive, Infinity }

[System.Serializable]
public class MapOption
{
    [SerializeField]
    private WinCodition condition;
    [SerializeField]
    private List<int> startWeaponsID = new List<int>() { 0 };
    [SerializeField]
    private List<int> shopWeaponsID = new List<int>() { 0, 1 };
    [SerializeField]
    private List<int> startStructuresID = new List<int>() { 0 };
    [SerializeField]
    private List<int> shopStructuresID = new List<int>() { 0, 1 };
    [SerializeField]
    private bool isDay;

    public List<int> StartWeaponsID { get => startWeaponsID; set => startWeaponsID = value; }
    public List<int> ShopWeaponsID { get => shopWeaponsID; set => shopWeaponsID = value; }
    public bool IsDay { get => isDay; set => isDay = value; }
    public List<int> StartStructuresID { get => startStructuresID; set => startStructuresID = value; }
    public List<int> ShopStructuresID { get => shopStructuresID; set => shopStructuresID = value; }

    public void Copy(MapOption option)
    {
        condition = option.condition;
        StartWeaponsID.AddRange(option.StartWeaponsID);
        ShopWeaponsID.AddRange(option.ShopWeaponsID);
        IsDay = option.isDay;
    }
}

public class MapManager : SingletonPersistence<MapManager>
{
    [SerializeField]
    private MapInfo selectedMap;
    [SerializeField]
    private MapOption options = new MapOption();

    public MapInfo SelectedMap { get => selectedMap; set => selectedMap = value; }
    public MapOption Options { get => options; set => options = value; }

    public void SetMapAndOption(MapInfo map, MapOption option)
    {
        SelectedMap = map;
        Options = option;

    }
}
