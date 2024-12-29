using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class NationSelectionUpdater : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nationNameUI;
    [SerializeField]
    private TextMeshProUGUI territoriesUI;
    [SerializeField]
    private TextMeshProUGUI oilUI;
    [SerializeField]
    private TextMeshProUGUI ironUI;
    [SerializeField]
    private TextMeshProUGUI otherUI;

    public void UpdateStats(NationSO nation)
    {
        if (nation == null)
        {
            nationNameUI.text = "N/A";
            territoriesUI.text = "0";
            oilUI.text = "0";
            ironUI.text = "0";
            otherUI.text = "0";
        }
        else
        {
            nationNameUI.text = nation.name;
            territoriesUI.text = nation.defaultOwnedTiles.Count.ToString();
            int oil = 0;
            int iron = 0;
            int other = 0;
            foreach (LandTile tile in nation.defaultOwnedTiles)
            {
                oil += tile.currentOil;
                iron += tile.currentIron;
                other += tile.currentOther;
            }
            oilUI.text = oil.ToString();
            ironUI.text = iron.ToString();
            otherUI.text = other.ToString();
        }
    }
}
