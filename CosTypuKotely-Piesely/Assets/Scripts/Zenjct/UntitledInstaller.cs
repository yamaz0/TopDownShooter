using System;
using System.Reflection;
using System.Linq;
using UnityEngine;
using Zenject;
using System.Collections.Generic;

public class UntitledInstaller : MonoInstaller<UntitledInstaller>
{
    public override void InstallBindings()
    {
        BindManagersFromSingletonType(typeof(Singleton<>));
        BindManagersFromSingletonType(typeof(SingletonScriptableObject<>));
        // Container.Bind<MapManager>().FromInstance(MapManager.Instance);
        // Container.Bind<StructureScriptableObject>().FromScriptableObjectResource("");
    }

    private void BindManagersFromSingletonType(Type type1)
    {
        List<Type> types = Assembly.GetAssembly(type1).GetTypes().Where(t => t.IsClass && !t.IsAbstract && IsSubclassOfRawGeneric(type1, t)).ToList();

        for (int i = 0; i < types.Count; i++)
        {
            Type type = types[i];
            Container.Bind(types[i]).FromInstance(FindObjectOfType(type));
        }
    }

    //https://stackoverflow.com/questions/457676/check-if-a-class-is-derived-from-a-generic-class
    bool IsSubclassOfRawGeneric(Type generic, Type toCheck)
    {
        while (toCheck != null && toCheck != typeof(object))
        {
            var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
            if (generic == cur)
            {
                return true;
            }
            toCheck = toCheck.BaseType;
        }
        return false;
    }
}