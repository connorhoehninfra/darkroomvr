using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiquidVolumeFX;

public class Tray : MonoBehaviour
{
    [SerializeField] private LiquidVolume lv;
    [SerializeField] private float totalFillThreshold;
    List<Color> liquidColours;
    void Start()
    {
        liquidColours = new List<Color>();
        if (!lv) lv = GetComponentInChildren<LiquidVolume>();
        lv.level = 0f;
        lv.alpha = 0f;
    }

    public void AddLiquid()
    {
        if (lv.level >= totalFillThreshold) return;

        lv.alpha = 1f;
        lv.level += 0.0001f;
    }


}
