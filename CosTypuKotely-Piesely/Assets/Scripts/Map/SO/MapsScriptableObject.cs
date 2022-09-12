using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapScriptableObject", menuName = "SO/MapScriptableObject")]
public class MapsScriptableObject: SingletonScriptableObject<MapsScriptableObject>
{
    public MapInfo GetMapInfoById(int id)
    {
        return (MapInfo)Objects.GetElementById(id);
    }

    public MapInfo GetMapInfoByName(string name)
    {
        return (MapInfo)Objects.GetElementByName(name);
    }

    public List<MapInfo> GetMapsList()
    {
        List<MapInfo> Maps = new List<MapInfo>(Objects.Count);

        foreach (MapInfo Map in Objects)
        {
            Maps.Add(Map);
        }

        return Maps;
    }
}
