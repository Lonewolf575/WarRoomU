using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NationHandler : Singleton<NationHandler>
{
    //public static NationHandler instance;

    public int number;
    [SerializeField]
    private GameObject map;
    [SerializeField]
    private GameObject flagToken;
    public Dictionary<string, NationSO> nations;
    public List<GameObject> flags;
    // Start is called before the first frame update
    void Awake()
    {
        number = 2;
        nations = new Dictionary<string, NationSO>();
        foreach (Transform child in map.transform)
        {
            LandTile tile = child.GetComponent<LandTile>();
            if (tile != null)
            {
                if (tile.defaultOwner != null)
                {
                    tile.currentOwner = tile.defaultOwner;
                    if (!nations.ContainsKey(tile.defaultOwner.nationName))
                    {
                        nations.Add(tile.defaultOwner.nationName, tile.defaultOwner);
                    }
                    MeshCollider collider = child.GetComponent<MeshCollider>();
                    Vector3 flagPos = new Vector3(collider.bounds.center.x, 0.0f, collider.bounds.center.z);
                    GameObject flag = ObjectHandler.Instance.serverInstance(flagToken, flagPos, Quaternion.identity);

                    Vector4 nationColor = tile.defaultOwner.nationColor;
                    flag.GetComponent<FlagTokenHandler>().changeFlagColorRpc(tile.defaultOwner.nationName);
                }
            }
        }
    }


    byte[] convertTextureToBytes(Texture2D texture)
    {
        byte[] bytes = null;
        bytes = texture.GetRawTextureData();
        return bytes;
    }

    //[ClientRpc]
    //public void updateTexturesClientRpc(GameObject flag, Color color, Texture flagTexture)
    //{
    //    MeshRenderer flagRenderer = flag.GetComponent<MeshRenderer>();
    //    flagRenderer.materials[0].color = color;
    //    flagRenderer.materials[1].SetTexture("_BaseMap", flagTexture);
    //}


    // Update is called once per frame
    //void Update()
    //{
    //    
    //}
}
