using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] int         LevelNumber;
    [SerializeField] TileManager tileManager;
    [SerializeField] Vector2     gameZoneOffset;
    Level paterns;

    //Change int by the tile class when done
    List<GameObject> Tiles;

	void Start ()
    {
        Tiles = new List<GameObject>();
        paterns = new Level();
        byte[,] currentLevel = new byte[paterns.SIZE_X, paterns.SIZE_Y];
        currentLevel = paterns.Levels[LevelNumber];
        currentLevel = paterns.Levels[LevelNumber];
        //Populate the map with patern
        for (int y = paterns.SIZE_Y-1; y >= 0; y--)
        {
            for (int x = 0; x < paterns.SIZE_X; x++)
            {
                GameObject currentTile = Instantiate(tileManager.GetPrefab(((TILE_TYPE)(currentLevel[y,x]))));
                currentTile.transform.position = new Vector3(x * 128 + gameZoneOffset.x, y * 128 + gameZoneOffset.y + 128, 0);
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
}
