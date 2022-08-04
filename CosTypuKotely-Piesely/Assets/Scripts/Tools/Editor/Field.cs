using UnityEditor;
using System;

public class Field
{
    object obj;
    Action<object> action = delegate { };
    string label;

    public object Obj { get => obj; set => obj = value; }
    public Action<object> Action { get => action; set => action = value; }
    public string LabelText { get => label; set => label = value; }

    public Field(object o, Action<object> a, string label)
    {
        Obj = o;
        Action = a;
        LabelText = label;
    }

    public void Show()
    {
        if (string.IsNullOrEmpty(LabelText) == false)
            EditorGUILayout.LabelField(LabelText);
        Action(Obj);
    }
}
