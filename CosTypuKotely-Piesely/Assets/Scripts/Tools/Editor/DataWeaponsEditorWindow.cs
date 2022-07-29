using UnityEngine;

[CreateAssetMenu(fileName = "DataWeaponsEditorWindow", menuName = "EditorScriptableObjects/DataWeaponsEditorWindow")]
[System.Serializable]
public class DataWeaponsEditorWindow : DataBasesEditorWindow
{
    public override void Init()
    {
        DataInstance = WeaponsScriptableObject.Instance;
    }
}
