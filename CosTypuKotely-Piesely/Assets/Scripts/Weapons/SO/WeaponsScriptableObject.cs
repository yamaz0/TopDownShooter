using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "SO/WeaponScriptableObject")]
public class WeaponsScriptableObject: SingletonScriptableObject<WeaponsScriptableObject>
{
    public WeaponInfo GetWeaponInfoById(int id)
    {
        return (WeaponInfo)Objects.GetElementById(id);
    }

    public WeaponInfo GetWeaponInfoByName(string name)
    {
        return (WeaponInfo)Objects.GetElementByName(name);
    }

    public List<WeaponInfo> GetWeaponsList()
    {
        List<WeaponInfo> Weapons = new List<WeaponInfo>(Objects.Count);

        foreach (WeaponInfo Weapon in Objects)
        {
            Weapons.Add(Weapon);
        }

        return Weapons;
    }
}
