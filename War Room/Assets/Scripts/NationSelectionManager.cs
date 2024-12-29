using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NationSelectionManager : MonoBehaviour
{

    [SerializeField]
    List<NationSO> nations;
    [SerializeField]
    GameObject nationButton;
    [SerializeField]
    Transform nationScrollField;
    [SerializeField]
    GameObject map;

    [SerializeField]
    GameObject statsUI;
    // Start is called before the first frame update
    void Awake()
    {
        List<NationSO> nationList = new List<NationSO>();
        foreach (Transform mapTile in map.transform)
        {
            LandTile tile = mapTile.gameObject.GetComponent<LandTile>();
            if (tile != null)
            {
                if (!nationList.Contains(tile.defaultOwner))
                {
                    nationList.Add(tile.defaultOwner);
                    tile.defaultOwner.defaultOwnedTiles.Clear();
                }
                tile.defaultOwner.defaultOwnedTiles.Add(tile);
            }
        }


        NationSelectionUpdater updater = statsUI.GetComponent<NationSelectionUpdater>();

        foreach (NationSO nation in nationList)
        {
            GameObject newNationButton = GameObject.Instantiate(nationButton, nationScrollField);
            newNationButton.GetComponent<NationSelectionButton>().populateButton(nation);
            newNationButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                updater.UpdateStats(nation);
            });
        }

    }
}
