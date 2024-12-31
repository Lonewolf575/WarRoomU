using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NationSelectionManager : MonoBehaviour
{
    [SerializeField]
    PlayerHandler playerHandler;
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

    [SerializeField]
    GameObject selectNationButton;


    Dictionary<string, GameObject> possibleNations;
    Dictionary<string, GameObject> selectedNations;
    string selectedNation;
    string activeNation;

    // Start is called before the first frame update
    void Awake()
    {
        selectNationButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            
            playerHandler.ChooseNationRpc(selectedNation, false);
            selectedNation = activeNation;
            playerHandler.ChooseNationRpc(selectedNation, true);
        });
        selectedNation = "";
        selectedNations = new Dictionary<string, GameObject>();
        possibleNations = new Dictionary<string, GameObject>();
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
                activeNation = nation.nationName;
                if (selectedNations.ContainsKey(nation.nationName))
                {
                    selectNationButton.GetComponent<Button>().interactable = false;
                }
                else
                {
                    selectNationButton.GetComponent<Button>().interactable = true;
                }
                updater.UpdateStats(nation);
            });
            possibleNations.Add(nation.nationName, newNationButton);
        }
    }

    public void nationSelected(string nation, bool isSelected)
    {
        if(isSelected)
        {
            selectedNations.Add(nation, possibleNations[nation]);
            if (activeNation == nation)
            {
                selectNationButton.GetComponent<Button>().interactable = false;
            }
        }
        else
        {
            if (selectedNations.ContainsKey(nation))
            {
                selectedNations.Remove(nation);
            }
            if (activeNation == nation)
            {
                selectNationButton.GetComponent<Button>().interactable = true;
            }
        }
        
    }
}
