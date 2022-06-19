#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class Cheats : MonoBehaviour
{
    // [MenuItem("Cheats/LoadPlayer")]
    // static void LoadPlayer()
    // {
    //     Player.Instance.LoadData();
    // }
    // [MenuItem("Cheats/SavePlayer")]
    // static void SavePlayer()
    // {
    //     Player.Instance.SaveData();
    // }

    public static string GetClassDetails(Type t, ref string searchPropertyName, string str = null)
    {
        // if (sList is null) sList = new List<string>();
        // if (str is null) str = t.Name;

        foreach (var propertyInfo in t.GetProperties())
        {
            if (propertyInfo.Name.Equals(searchPropertyName))
            {
                searchPropertyName = string.Empty;
                return searchPropertyName;
            }

            if (string.IsNullOrEmpty(str) == true)
                str = propertyInfo.Name;
            else
                str = $"{str}.{propertyInfo.Name}";

            if (propertyInfo.PropertyType.IsClass)
            {
                string v = GetClassDetails(propertyInfo.PropertyType, ref searchPropertyName, str);
                if (string.IsNullOrEmpty(v) == false)
                    str = $"{str}.{v}";

            }
            if (string.IsNullOrEmpty(searchPropertyName)) break;
            // sList.Add(str);
            str = "";
        }

        return str;
    }


    [MenuItem("Cheats/test")]
    static void PrintRandomAtributesValues()
    {
        GameManager.Instance.ChangeWaveState();
    }

    [MenuItem("Cheats/TimeCouting")]
    static void TimeCouting()
    {
        //     System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        //     System.TimeSpan t=new System.TimeSpan();
        //     // ItemsManager instance = ItemsManager.Instance;
        //     List<ModificatorInfo> modyficatorsInfo = ModificatorsSO.Instance.ModyficatorsInfo;



        //     t = new System.TimeSpan();
        //     for (int i = 0; i < 10000; i++)
        //     {
        //         sw = System.Diagnostics.Stopwatch.StartNew();
        //         sw.Start();

        //     foreach (ModificatorInfo info in modyficatorsInfo)
        //     {
        //         Modificator propertyInfo = ModificatorsSO.GetModifier(Player.Instance.Character, info);
        //     }

        //         sw.Stop();
        //         t+=sw.Elapsed;
        //     }
        //     Debug.Log("Elapsed2="+t);
    }

}



#endif