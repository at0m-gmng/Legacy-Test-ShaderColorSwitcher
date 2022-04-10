using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button_spawner : MonoBehaviour
{
    [SerializeField] private Transform buttonsColor;

    private void Start()
    {
        var counter = 0;
        //int colorCount = color_manger.Instance.CellColor.Length;
        foreach (Color CellColor in color_manger.Instance.CellColor)
        {
            counter++;
            var cell = Instantiate(buttonsColor, this.transform);
            cell.name = "Button " + counter;
            var cellColor = cell.GetComponent<Image>();
            cellColor.color = CellColor;
            
        }
    }
}
