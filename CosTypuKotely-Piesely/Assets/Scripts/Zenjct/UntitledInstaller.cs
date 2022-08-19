using System;
using System.Reflection;
using System.Linq;
using UnityEngine;
using Zenject;
using System.Collections.Generic;

public class UntitledInstaller : MonoInstaller
{

    public override void InstallBindings()
    {
        BindManagersFromSingletonType(typeof(Singleton<>));
        BindManagersFromSingletonType(typeof(SingletonScriptableObject<>));
        // Container.Bind<StructureScriptableObject>().FromScriptableObjectResource("");
    }

    private void BindManagersFromSingletonType(Type type1)
    {
        List<Type> types = Assembly.GetAssembly(type1).GetTypes().Where(t => t.IsClass && !t.IsAbstract && IsSubclassOfRawGeneric(type1, t)).ToList();

        for (int i = 0; i < types.Count; i++)
        {
            Type type = types[i];
            PropertyInfo propertyInfo = type.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy | BindingFlags.Instance);
            object t = propertyInfo.GetValue(null, null);
            Container.Bind(types[i]).FromInstance(t);
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