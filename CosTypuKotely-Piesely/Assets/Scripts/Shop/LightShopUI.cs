using System.Collections.Generic;
using UnityEngine;

public class LightShopUI : MonoBehaviour
{
    [SerializeField]
    private List<ShopAttributeUI> stats;
    [SerializeField]
    private GameObject lightTab;
    private void OnEnable()
    {
        if (LightManager.Instance.IsDay == true)
        {
            lightTab.SetActive(true);
            foreach (var stat in stats)
            {
                stat.Init();
            }
        }
        else
        {
            lightTab.SetActive(false);
        }
    }

    private void OnDisable()
    {
        foreach (var stat in stats)
        {
            stat.DetachEvents();
        }
    }

}