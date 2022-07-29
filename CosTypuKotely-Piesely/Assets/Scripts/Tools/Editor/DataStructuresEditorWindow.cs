using UnityEngine;

[CreateAssetMenu(fileName = "DataStructuresEditorWindow", menuName = "EditorScriptableObjects/DataStructuresEditorWindow")]
public class DataStructuresEditorWindow : DataBasesEditorWindow
{
    public override void Init()
    {
        DataInstance = StructureScriptableObject.Instance;
    }
}
