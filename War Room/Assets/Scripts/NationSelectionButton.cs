using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class NationSelectionButton : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nationName;
    [SerializeField]
    private Image flag;
    public void populateButton(NationSO nation)
    {
        flag.sprite = nation.nationFlag;
        nationName.text = nation.nationName;
    }
}
