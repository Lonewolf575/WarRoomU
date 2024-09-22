using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class TextureManager : MonoBehaviour
{
    public static TextureManager instance;
    public List<NationSO> nationInfo;
    public Dictionary<string, NationSO> nationInfos = new Dictionary<string, NationSO>();
    private void Awake()
    {
        instance = this;
        foreach (NationSO nation in nationInfo)
        {
            nationInfos.Add(nation.nationName, nation);
        }
    }
    
}
