using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Nation", menuName = "Nation")]
public class NationSO : ScriptableObject
{
    public string nationName;
    public string owner;
    public List<LandTile> defaultOwnedTiles;
    public List<LandTile> ownedTiles;
    public Sprite nationFlag;
    public Texture2D tokenFlag;
    public Color nationColor;
}
