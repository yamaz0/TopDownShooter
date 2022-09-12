using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectElementsUI : MonoBehaviour
{
    [SerializeField]
    private List<SelectElementUI> elements;

    public List<SelectElementUI> Elements { get => elements; set => elements = value; }
}
