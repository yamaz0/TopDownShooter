using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnvironmentController : MonoBehaviour
{
    [SerializeField]
    private Tilemap tilemap;
    [SerializeField]
    private Tile t;

    public void Init()
    {
        Sprite s = MapManager.Instance.SelectedMap.Icon;
        t.sprite = s;

        for (int i = 0; i < 51; i++)
        {
            for (int j = 0; j < 26; j++)
            {
                tilemap.SetTile(new Vector3Int(i, j, 0), t);
            }
        }
        tilemap.RefreshAllTiles();
    }
}
