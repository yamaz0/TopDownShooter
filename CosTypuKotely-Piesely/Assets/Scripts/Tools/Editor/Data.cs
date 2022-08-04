using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

public class Data
{
    private int FieldsHeight { get; set; }
    public int MaxFieldsHeight { get; set; }
    public List<TileInfo> TileInfos { get; set; } = new List<TileInfo>();
    public Dictionary<Type, Action<object>> FieldsDictionary { get; set; } = new Dictionary<Type, Action<object>>();

    public void Init()
    {
        FieldsDictionary.Clear();
        FillDictionary();
    }

    public void Add(List<BaseInfo> list)
    {
        MaxFieldsHeight = 0;
        foreach (BaseInfo element in list)
        {
            Add(element);
        }
    }

    public void Add(BaseInfo element)
    {
        FieldsHeight = 0;
        List<Field> fields = GetAllFields(element);

        if (MaxFieldsHeight < FieldsHeight)
            MaxFieldsHeight = FieldsHeight;

        TileInfo info = new TileInfo(element);
        info.Fields.AddRange(fields);
        TileInfos.Add(info);
    }

    public void Sort(Comparer<TileInfo> comparer)
    {
        TileInfos.Sort(comparer);
    }

    public void FillDictionary()
    {
        FieldsDictionary.Add(typeof(int), (obj) =>
        {
            int x = (int)obj;
            GUILayout.Label(x.ToString());
        });

        FieldsDictionary.Add(typeof(float), (obj) =>
        {
            float x = (float)obj;
            GUILayout.Label(x.ToString());
        });

        FieldsDictionary.Add(typeof(double), (obj) =>
        {
            double x = (double)obj;
            GUILayout.Label(x.ToString());
        });

        FieldsDictionary.Add(typeof(Sprite), (obj) =>
        {
            Sprite x = (Sprite)obj;
            GUILayout.Box(Utils.GenerateTextureFromSprite(x), GUILayout.Width(100), GUILayout.Height(50));
        });

        FieldsDictionary.Add(typeof(string), (obj) =>
        {
            GUILayout.Label((string)obj);
        });

        FieldsDictionary.Add(typeof(object), (obj) =>
        {
            GUILayout.Label("Tu jakas klasa przykladowa zawierajaca pole");
            GetAllFields(obj);
        });
    }

    private List<Field> GetAllFields(object obj)
    {
        PropertyInfo[] propertyInfos = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        string label = string.Empty;
        List<Field> fields = new List<Field>();
        foreach (var propertyInfo in propertyInfos)
        {
            Type t = propertyInfo.PropertyType;

            // if (t.IsGenericType == true)
            // {
            //     t = typeof(IList);
            // }

            object value = propertyInfo.GetValue(obj, null);
            label = $"{propertyInfo.Name}:";

            bool v = FieldsDictionary.TryGetValue(t, out Action<object> f);

            if (v == false)
            {
                label = $"{t} handle not exist";
                continue;
            }
            Field field = new Field(value, f, label);
            FieldsHeight += 60;
            fields.Add(field);
            // f(value);
        }
        return fields;
    }

}
