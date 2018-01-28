using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] int         LevelNumber;
    [SerializeField] TileManager tileManager;
    [SerializeField] Vector2     gameZoneOffset;
    Level paterns;
    bool clicked = false;

    //Change int by the tile class when done
    List<GameObject> Tiles;

    private void Start()
    {
        Tiles = new List<GameObject>();
        paterns = new Level();
        byte[,] currentLevel = new byte[paterns.SIZE_X, paterns.SIZE_Y];
        currentLevel = paterns.Levels[LevelNumber];
        currentLevel = paterns.Levels[LevelNumber];
        //Populate the map with patern
        for (int y = 0; y < paterns.SIZE_Y; ++y)
        {
            for (int x = 0; x < paterns.SIZE_X; x++)
            {
                GameObject currentTile = Instantiate(tileManager.GetPrefab(((TILE_TYPE)(currentLevel[y, x]))));
                currentTile.transform.localPosition = new Vector3(x*128 + gameZoneOffset.x, gameZoneOffset.y - y*128, 0);
                Tiles.Add(currentTile);
            }
        }
    }

    bool IsTileValid(int x, int y)
    {
        if (x >= 0 && x < paterns.SIZE_X && y >= 0 && y < paterns.SIZE_Y)
        {
            if (Tiles[(paterns.SIZE_Y - y - 1) * paterns.SIZE_X + x])
                return true;
        }
        return false;
    }

    Tile GetTile(int x, int y)
    {
        if (IsTileValid(x, y))
            return Tiles[y * paterns.SIZE_X + x].GetComponent<Tile>();
        return null;
    }

    public Tile FindTile()
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, 
                        Input.mousePosition.y, 
                        1));

        return GetTile((int)point.x, (int)point.y);
    }

    void OnMouseDown()
    {
        if(!clicked)
        {
            clicked = true;
            //AddCurrentBuildingto FindTile();
        }
    }
    void OnMouseUp()
    {
        clicked = false;
    }
}
