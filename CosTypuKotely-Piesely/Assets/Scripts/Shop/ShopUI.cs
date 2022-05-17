using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShopUI : MonoBehaviour
{
    [SerializeField]
    private StatUI hp;
    [SerializeField]
    private StatUI armor;
    [SerializeField]
    private StatUI gold;

    private void OnEnable()
    {
        hp.Init();
        armor.Init();
        gold.Init();
    }

    private void OnDisable()
    {
        hp.DetachEvents();
        armor.DetachEvents();
        gold.DetachEvents();
    }
}