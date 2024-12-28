using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class textEnabledbutton : MonoBehaviour
{
    [SerializeField]
    List<Button> buttons;
    [SerializeField]
    TMP_InputField textField;
    private bool bEnabled = false;

    private void Start()
    {
        textField.onValueChanged.AddListener((string text) =>
        {
            if (text != "")
            {
                Debug.Log(text);
                if (!bEnabled)
                {
                    bEnabled = true;
                    foreach (Button button in buttons)
                    {
                        button.interactable = true;
                    }
                }
            }
            else
            {
                if (bEnabled)
                {
                    bEnabled = false;
                    foreach (Button button in buttons)
                    {
                        button.interactable = false;
                    }
                }
            }
        });
    }
}
