using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandTile : Tile
{
    public int currentOil;
    public int warTornOil;
    public int totalOil;
    public int currentIron;
    public int warTornIron;
    public int totalIron;
    public int currentOther;
    public int warTornOther;
    public int totalOther;
    public int stressWorth;
    public int factoryCount;

    public bool isWarTorn;
    public bool isCapital;

    public NationSO defaultOwner;
    public NationSO currentOwner;
    public GameObject flag;

    private void Awake()
    {
        if (isWarTorn)
        {
            currentOil = warTornOil;
            currentIron = warTornIron;
            currentOther = warTornOther;
        }
        else
        {
            currentOil = totalOil;
            currentIron = totalIron;
            currentOther = totalOther;
        }
    }
}