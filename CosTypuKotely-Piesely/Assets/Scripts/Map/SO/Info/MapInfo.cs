using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class MapInfo : BaseInfo
{
    [SerializeField]
    private MapOption defaultMapOption;
    [SerializeField]
    private Tilemap tilemap;
    [SerializeField]
    private string description;
    [SerializeField]
    private Sprite icon;

    public MapOption DefaultMapOption { get => defaultMapOption; set => defaultMapOption = value; }
    public Tilemap Tilemap { get => tilemap; set => tilemap = value; }
    public string Description { get => description; set => description = value; }
    public Sprite Icon { get => icon; set => icon = value; }

    public MapInfo()
    {

    }
    public MapInfo(MapInfo info) : base(info)
    {

    }

}
