using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInfo : MonoBehaviour
{
    public static playerInfo instance;

    public string playerName;
    public int playerId;

    private void Awake()
    {
        instance = this;
    }
}
