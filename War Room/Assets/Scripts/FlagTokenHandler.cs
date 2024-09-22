using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class FlagTokenHandler : NetworkBehaviour
{
    [Rpc(SendTo.Everyone)]
    public void changeFlagColorRpc(string nationName)
    {
        MeshRenderer flagMesh = this.GetComponent<MeshRenderer>();
        NationSO nation = TextureManager.instance.nationInfos[nationName];
        flagMesh.materials[0].color = nation.nationColor;
        flagMesh.materials[1].SetTexture("_BaseMap", nation.tokenFlag);
    }
}
