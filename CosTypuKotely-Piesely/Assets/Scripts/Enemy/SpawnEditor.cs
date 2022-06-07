using UnityEditor;
using UnityEngine;

[UnityEditor.CustomEditor(typeof(Spawn)), CanEditMultipleObjects]
public class SpawnEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        var script = (Spawn)target;

        if (GUILayout.Button($"Add wave", GUILayout.Height(40)))
        {
            script.Wave = new InfinityWave();
        }
        base.OnInspectorGUI();
    }
}
