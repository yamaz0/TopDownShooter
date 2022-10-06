using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CirclePositionTransformEditorWindow : EditorWindow
{

    public Transform Center { get; set; }
    public List<Transform> Objects { get; set; } = new List<Transform>();
    public float R { get; set; }
    public float parts { get; set; }
    [MenuItem("Tools/CirclePositionTransformWindow")]
    private static void ShowWindow()
    {
        var window = GetWindow<CirclePositionTransformEditorWindow>();
        window.titleContent = new GUIContent("CirclePositionTransformWindow");
        window.Show();
    }

    private void OnGUI()
    {
        if (GUILayout.Button("SetCenter"))
            Center = Selection.activeGameObject.transform;
        if (GUILayout.Button("SetObjects"))
        {
            Objects.Clear();
            var objs = Selection.gameObjects;
            foreach (var obj in objs)
            {
                Objects.Add(obj.transform);
            }
        }

        R = EditorGUILayout.FloatField("R", R);
        parts = EditorGUILayout.FloatField("how many parts", parts);

        if (GUILayout.Button("Set Positions"))
        {
            float deg = 0;
            float divideDeg = 360f / parts;

            for (int i = 0; i < parts; i++)
            {
                float x = Center.position.x + R * Mathf.Cos(Mathf.Deg2Rad * deg);
                float y = Center.position.y + R * Mathf.Sin(Mathf.Deg2Rad * deg);
                deg += divideDeg;

                Objects[i].position = new Vector3(x, y, 0);
                Objects[i].Rotate(0, 0, deg);
            }
        }

        if (Center != null)
            GUILayout.Label($"Center: {Center.name} {Center.position}");
        if (Objects.Count > 0)
        {
            for (int i = 0; i < Objects.Count; i++)
            {
                GUILayout.Label($"{i}: {Objects[i].name} {Objects[i].position}");
            }
        }


    }
}