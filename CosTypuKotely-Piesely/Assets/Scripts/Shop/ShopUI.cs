using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField]
    private GameObject lightTab;

    private void OnEnable()
    {
        if (LightManager.Instance.IsDay == false)
        {
            lightTab.SetActive(true);
        }
        else
        {
            lightTab.SetActive(false);
        }
    }
}