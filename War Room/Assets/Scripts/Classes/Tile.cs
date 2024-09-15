using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public string tileName;
    public List<Tile> adjacentTiles;
    public bool selected = false;

    private void Start()
    {
        foreach (Tile tile in adjacentTiles)
        {
            if (tile == this)
            {
                Debug.Log("Warning: tile:" + this.name + " is contained within itself.");
                Material mat = getMat(this.gameObject, "Outline");
                mat.SetColor("_BaseColor", Color.yellow);
            }
            else if (!tile.adjacentTiles.Contains(this))
            {
                Debug.Log("Warning: tile:" + tile.name + " does not contain tile " + this.name);
                Material mat = getMat(tile.gameObject, "Outline");
                mat.SetColor("_BaseColor", Color.red);
            }
        }
    }

    private Material getMat(GameObject tile, string name)
    {
        MeshRenderer mr = tile.GetComponent<MeshRenderer>();
        Material mat = null;
        if (mr != null)
        {
            foreach (Material material in mr.materials)
            {
                if (material.name.Contains(name))
                {
                    mat = material;
                }
            }
        }
        return mat;
    }

    public IEnumerator visualSelect()
    {
        
        selected = true;
        float tick = 0f;
        Material mat = getMat(this.gameObject, "Outline");
        Color originalColor = mat.color;
        while (selected)
        {
            tick += Time.deltaTime * 1;
            mat.color = Color.Lerp(originalColor, Color.black, Mathf.PingPong(Time.time, 1));
            yield return null;
        }
        mat.color = originalColor;
    }
}
