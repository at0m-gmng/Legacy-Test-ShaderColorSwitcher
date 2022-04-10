using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Gameplay/New Data")]
public class dataData : ScriptableObject
{
    [SerializeField] private Sprite[] _sprite;
    [SerializeField] private float[] _HSV_Color_Range_Min_1;
    [SerializeField] private float[] _HSV_Color_Range_Max_1;
    [SerializeField] private float[] _HSV_Color_Range_Min_2;
    [SerializeField] private float[] _HSV_Color_Range_Max_2;
    [SerializeField] private float[] _HSV_Color_Range_Min_3;
    [SerializeField] private float[] _HSV_Color_Range_Max_3;

    public Sprite[] sprite => this._sprite;
    public float[] HSV_Color_Range_Min_1 => this._HSV_Color_Range_Min_1;
    public float[] HSV_Color_Range_Max_1 => this._HSV_Color_Range_Max_1;
    public float[] HSV_Color_Range_Min_2 => this._HSV_Color_Range_Min_2;
    public float[] HSV_Color_Range_Max_2 => this._HSV_Color_Range_Max_2;
    public float[] HSV_Color_Range_Min_3 => this._HSV_Color_Range_Min_3;
    public float[] HSV_Color_Range_Max_3 => this._HSV_Color_Range_Max_3;
}
