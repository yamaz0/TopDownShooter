using UnityEngine;
using Zenject;

[System.Serializable]
public class MapSelectUI
{
    [SerializeField]
    MapOption mapOption;

    [SerializeField]
    TMPro.TMP_Text mapName;
    [SerializeField]
    TMPro.TMP_Text mapDescription;

    public MapElementUI SelectedMapElement { get; set; }
    public MapOption MapOption { get => mapOption; set => mapOption = value; }

    public void SetInfo(MapElementUI mapElementUI)
    {
        SelectedMapElement?.SetSelected(false);

        MapInfo info = mapElementUI.Info;
        mapName.SetText(info.Name);
        mapDescription.SetText(info.Description);
        MapOption.Copy(info.DefaultMapOption);
        SelectedMapElement = mapElementUI;
    }
}
