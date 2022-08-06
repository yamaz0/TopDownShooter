using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelUI : MonoBehaviour
{
    [SerializeField]
    private List<WheelElementUI> elements;

    public List<WheelElementUI> Elements { get => elements; set => elements = value; }
}
