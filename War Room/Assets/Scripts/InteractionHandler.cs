using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    // Update is called once per frame
    List<Tile> selectedTiles;
    Tile selectedTile;
    [SerializeField]
    Camera cam;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Tile clickedTile = hit.transform.gameObject.GetComponent<Tile>();
                if (clickedTile != null)
                {
                    deselectTile(selectedTile);
                    selectedTile = null;
                    IEnumerator coroutine = clickedTile.visualSelect();
                    StartCoroutine(coroutine);
                    selectedTile = clickedTile;
                    //selectedTiles.Add(clickedTile);
                }
                else
                {
                    deselectTile(selectedTile);
                    selectedTile = null;
                }
            }
            else
            {
                deselectTile(selectedTile);
                selectedTile = null;
            }
        }
    }

    private void deselectTiles(List<Tile> thing)
    {
        foreach (Tile tile in selectedTiles)
        {
            tile.selected = false;
        }
    }

    private void deselectTile(Tile tile)
    {
        if (tile != null)
        {
            tile.selected = false;
        }
    }

    private List<Tile> pingRadious(int rad, List<Tile> tiles)
    {
        foreach (Tile tile in tiles)
        {

        }
        return tiles;
    } 
}
