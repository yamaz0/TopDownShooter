using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : Singleton<WindowManager>
{
    [SerializeField]
    private GameObject shop;


    public void ShowShop()
    {
        shop.SetActive(!shop.activeSelf);
    }
}
