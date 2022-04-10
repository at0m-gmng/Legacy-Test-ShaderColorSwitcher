using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color_manger : MonoBehaviour
{
    public static color_manger Instance;

    public Color[] CellColor; // хранит цвета плиток

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}
