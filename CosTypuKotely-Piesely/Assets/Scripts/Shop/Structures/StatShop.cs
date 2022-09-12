using System.Collections.Generic;
using UnityEngine;

public class StatShop : MonoBehaviour
{
    [SerializeField]
    private List<ShopAttributeUI> stats;

    private void OnEnable()
    {
        foreach (var stat in stats)
        {
            stat.Init();
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
