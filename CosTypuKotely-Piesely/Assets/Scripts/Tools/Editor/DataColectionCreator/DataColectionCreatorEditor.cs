using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
public class DataColectionCreatorEditor : EditorWindow
{

    string Name { get; set; }
    string Path { get; set; }
    string FullPath { get; set; }

    [MenuItem("Editors/DataColectionCreator")]
    private static void ShowWindow()
    {
        var window = GetWindow<DataColectionCreatorEditor>();
        window.titleContent = new GUIContent("DataColectionCreator");
        window.Show();
    }

    private void OnGUI()
    {
        Name = EditorGUILayout.TextField("Data name", Name);
        Path = EditorGUILayout.TextField("Path", Path);
        EditorGUILayout.LabelField("If empty it takes the selected folder. Otherwise it creates a folder in Assets/Scripts/[Path]");

        if (GUILayout.Button("Create"))
        {
            if (String.IsNullOrEmpty(Path))
            {
                string folderPath = AssetDatabase.GetAssetPath(Selection.activeInstanceID);
                if (folderPath.Contains("."))
                    folderPath = folderPath.Remove(folderPath.LastIndexOf('/'));
                FullPath = folderPath;
            }
            else
            {
                FullPath = $"Assets/Scripts/{Path}";
                Directory.CreateDirectory(FullPath);
            }
            CreateNewDataColection();
        }
    }

    public void CreateNewDataColection()
    {
        File.WriteAllText(FullPath + "/" + Name + ".cs", GetNameScriptPattern());

        Directory.CreateDirectory(FullPath + "/Editor");
        File.WriteAllText(FullPath + "/Editor" + "/" + Name + "sScriptableObjectEditor.cs", GetNameScriptableObjectEditorPattern());

        Directory.CreateDirectory(FullPath + "/SO");
        File.WriteAllText(FullPath + "/SO" + "/" + Name + "sScriptableObject.cs", GetNameScriptableObjectPattern());

        Directory.CreateDirectory(FullPath + "/SO/Info");
        File.WriteAllText(FullPath + "/SO/Info" + "/" + Name + "Info.cs", GetNameInfoPattern());
    }

    private string GetNameScriptPattern()
    {
        return @$"using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class {Name} : MonoBehaviour
{{


}}";
    }

    private String GetNameInfoPattern()
    {
        return $@"using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class {Name}Info : BaseInfo
{{
    public {Name}Info()
    {{

    }}
    public {Name}Info({Name}Info info) : base(info)
    {{

    }}

}}
";
    }
    private String GetNameScriptableObjectEditorPattern()
    {
        return $@"using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[UnityEditor.CustomEditor(typeof({Name}sScriptableObject))]
public class {Name}sScriptableObjectEditor : UnityEditor.Editor
{{
    // List<System.Type> types;
    public {Name}sScriptableObjectEditor()
    {{
        // types = System.Reflection.Assembly.GetAssembly(typeof({Name}Info)).GetTypes().Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof({Name}Info))).ToList();
    }}
    public override void OnInspectorGUI()
    {{
        var script = ({Name}sScriptableObject)target;

        // foreach (var t in types)
        // {{
            // string[] typeNames = t.ToString().Split('+');
            // if (GUILayout.Button($""Add {{typeNames[typeNames.Length - 1]}}"", GUILayout.Height(40)))
            // {{
            //     {Name}Info {Name} = System.Activator.CreateInstance(t) as {Name}Info;
            //     {Name}.Id = script.Objects.Count;
            //     script.Objects.Add({Name});
            // }}
        // }}
            if (GUILayout.Button($""Add {Name}Info"", GUILayout.Height(40)))
            {{
                {Name}Info {Name} = new {Name}Info();
                {Name}.Id = script.Objects.Count;
                script.Objects.Add({Name});
            }}

        base.OnInspectorGUI();
    }}
}}
";
    }

    private String GetNameScriptableObjectPattern()
    {
        return $@"using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = ""{Name}ScriptableObject"", menuName = ""SO/{Name}ScriptableObject"")]
public class {Name}sScriptableObject: SingletonScriptableObject<{Name}sScriptableObject>
{{
    public {Name}Info Get{Name}InfoById(int id)
    {{
        return ({Name}Info)Objects.GetElementById(id);
    }}

    public {Name}Info Get{Name}InfoByName(string name)
    {{
        return ({Name}Info)Objects.GetElementByName(name);
    }}

    public List<{Name}Info> Get{Name}sList()
    {{
        List<{Name}Info> {Name}s = new List<{Name}Info>(Objects.Count);

        foreach ({Name}Info {Name} in Objects)
        {{
            {Name}s.Add({Name});
        }}

        return {Name}s;
    }}
}}
";
    }
}