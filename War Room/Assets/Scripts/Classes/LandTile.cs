using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandTile : Tile
{
    public struct landResources
    {
        int currentOil;
        int warTornOil;
        int totalOil;
        int currentIron;
        int warTornIron;
        int totalIron;
        int currentOther;
        int warTornOther;
        int totalOther;
        int stressWorth;
        int factoryCount;
    }
}