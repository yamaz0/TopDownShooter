using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class MapMenuUI : SelectElementsUI
{
    [SerializeField]
    private MapSelectUI mapSelectUI;

    [SerializeField]
    private Transform content;
    [SerializeField]
    private MapElementUI template;

    [Inject]
    MapsScriptableObject MapsScriptableObjectInstance { get; set; }
    [Inject]
    MapManager MapManagerInstance { get; set; }

    private void OnEnable()
    {
        List<MapInfo> mapsInfos = MapsScriptableObjectInstance.GetMapsList();

        Elements.ClearAndDestroy();

        foreach (MapInfo info in mapsInfos)
        {
            MapElementUI newElement = Instantiate(template, content);
            newElement.Init(info);
            newElement.OnMapElementClicked += mapSelectUI.SetInfo;
            newElement.gameObject.SetActive(true);

            Elements.Add(newElement);
        }
    }

    public void OnStartButtonClicked()
    {
        // MapManager.Instance.SetMapAndOption(mapSelectUI.SelectedMapElement.Info, mapSelectUI.MapOption);
        MapManagerInstance.SetMapAndOption(mapSelectUI.SelectedMapElement.Info, mapSelectUI.MapOption);
        SceneManager.LoadScene("Gameplay");
    }

}