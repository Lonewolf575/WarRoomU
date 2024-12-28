using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NationSelectionManager : MonoBehaviour
{

    [SerializeField]
    List<NationSO> nations;
    [SerializeField]
    GameObject nationButton;
    [SerializeField]
    Transform nationScrollField;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (NationSO nation in nations)
        {
            GameObject newNationButton = GameObject.Instantiate(nationButton, nationScrollField);
            newNationButton.GetComponent<NationSelectionButton>().populateButton(nation);
        }

    }
}
