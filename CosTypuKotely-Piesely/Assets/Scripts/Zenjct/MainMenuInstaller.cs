using System;
using System.Reflection;
using System.Linq;
using UnityEngine;
using Zenject;
using System.Collections.Generic;

public class MainMenuInstaller : MonoInstaller<MainMenuInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<MapManager>().FromInstance(FindObjectOfType<MapManager>());
        Container.Bind<MapsScriptableObject>().FromInstance(MapsScriptableObject.Instance);
    }
}
