using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] int         LevelNumber;
    [SerializeField] TileManager tileManager;
    [SerializeField] BuildingManager    buildingManager;
    [SerializeField] Vector2     gameZoneOffset;
    public BUILDING_TYPE currentBuilding;
    Tile currentTile;
    Level paterns;
    public bool clicked = false;

    //Change int by the tile class when done
    List<GameObject> Tiles;

    private void Start()
    {
        Tiles = new List<GameObject>();
        paterns = new Level();
        byte[,] currentLevel = new byte[paterns.SIZE_X, paterns.SIZE_Y];
        currentLevel = paterns.Levels[LevelNumber];
        //Populate the map with patern
        for (int y = 0; y < paterns.SIZE_Y; ++y)
        {
            for (int x = 0; x < paterns.SIZE_X; x++)
            {
                GameObject currentTile = Instantiate(tileManager.GetPrefab(((TILE_TYPE)(currentLevel[y, x]))));
                currentTile.transform.position = new Vector3(x*128 + gameZoneOffset.x, gameZoneOffset.y - y*128, -(float)y/10.0f);
                Tiles.Add(currentTile);
            }
        }
    }

    public bool IsTileValid(int x, int y)
    {
        if (x >= 0 && x < paterns.SIZE_X && y >= 0 && y < paterns.SIZE_Y)
        {
            if (Tiles[(paterns.SIZE_Y - y - 1) * paterns.SIZE_X + x])
                return true;
        }
        return false;
    }

    public Tile GetTile(int x, int y)
    {
        if (IsTileValid(x, y))
        {
            return Tiles[y * paterns.SIZE_X + x].GetComponent<Tile>();
        }
        return null;
    }

    public Tile GetTile(Vector2 pos)
    {
        return GetTile((int)pos.x, (int)pos.y);
    }

    public Vector2 FindTile(Tile tile)
    {
        float x = tile.gameObject.transform.position.x;
        float y = tile.gameObject.transform.position.y;
        Debug.Log(new Vector2((x - gameZoneOffset.x) / 128, -(y - gameZoneOffset.y) / 128));
        return new Vector2((x - gameZoneOffset.x) / 128, -(y - gameZoneOffset.y) / 128);
    }

    public void AddComponentOnTile(Tile tile)
    {
        GameObject b = Instantiate(buildingManager.GetPrefab(currentBuilding));
        Building building = b.GetComponent<Building>();
        Tile t2 = GetTile(FindTile(tile));

        Vector2 v1 = FindTile(currentTile);
        Vector2 v2 = FindTile(tile);

        Vector2 v = v1 - v2;


        switch (currentBuilding)
        {
            case BUILDING_TYPE.CABLE:
                if (v == new Vector2(1, 0))
                {
                    tile.AddBuilding(building, DIRECTION.RIGHT, POSITION_TYPE.CENTER, true, false);
                    currentTile.AddBuilding(building, DIRECTION.LEFT, POSITION_TYPE.CENTER, false, false);
                }
                if (v == new Vector2(0, -1))
                {
                    tile.AddBuilding(building, DIRECTION.BOTTOM, POSITION_TYPE.CENTER, true, false);
                    currentTile.AddBuilding(building, DIRECTION.TOP, POSITION_TYPE.CENTER, false, false);
                }
                if (v == new Vector2(-1, 0))
                {
                    tile.AddBuilding(building, DIRECTION.LEFT, POSITION_TYPE.CENTER, true, false);
                    currentTile.AddBuilding(building, DIRECTION.RIGHT, POSITION_TYPE.CENTER, false, false);
                }
                if (v == new Vector2(0, 1))
                {
                    tile.AddBuilding(building, DIRECTION.TOP, POSITION_TYPE.CENTER, true, false);
                    currentTile.AddBuilding(building, DIRECTION.BOTTOM, POSITION_TYPE.CENTER, false, false);
                }
                break;
            case BUILDING_TYPE.WIFI:
                if (v == new Vector2(1, 1))
                {
                    tile.AddBuilding(building, DIRECTION.TOP_RIGHT, POSITION_TYPE.CENTER, true, false);
                    currentTile.AddBuilding(building, DIRECTION.BOTTOM_LEFT, POSITION_TYPE.CENTER, false, false);
                }
                if (v == new Vector2(1, -1))
                {
                    tile.AddBuilding(building, DIRECTION.BOTTOM_RIGHT, POSITION_TYPE.CENTER, true, false);
                    currentTile.AddBuilding(building, DIRECTION.TOP_LEFT, POSITION_TYPE.CENTER, false, false);
                }
                if (v == new Vector2(-1, -1))
                {
                    tile.AddBuilding(building, DIRECTION.BOTTOM_LEFT, POSITION_TYPE.CENTER, true, false);
                    currentTile.AddBuilding(building, DIRECTION.TOP_RIGHT, POSITION_TYPE.CENTER, false, false);
                }
                if (v == new Vector2(-1, 1))
                {
                    tile.AddBuilding(building, DIRECTION.TOP_LEFT, POSITION_TYPE.CENTER, true, false);
                    currentTile.AddBuilding(building, DIRECTION.BOTTOM_RIGHT, POSITION_TYPE.CENTER, false, false);
                }
                break;
            case BUILDING_TYPE.LASER:
                if (v.x > 1 && v.y == 0)
                {
                    tile.AddBuilding(building, DIRECTION.RIGHT, POSITION_TYPE.CENTER, true, false);
                    currentTile.AddBuilding(building, DIRECTION.LEFT, POSITION_TYPE.CENTER, false, false);
                }
                if (v.x == 0 && v.y < -1)
                {
                    tile.AddBuilding(building, DIRECTION.BOTTOM, POSITION_TYPE.CENTER, true, false);
                    currentTile.AddBuilding(building, DIRECTION.TOP, POSITION_TYPE.CENTER, false, false);
                }
                if (v.x < -1 && v.y == 0)
                {
                    tile.AddBuilding(building, DIRECTION.LEFT, POSITION_TYPE.CENTER, true, false);
                    currentTile.AddBuilding(building, DIRECTION.RIGHT, POSITION_TYPE.CENTER, false, false);
                }
                if (v.x == 0 && v.y > 1)
                {
                    tile.AddBuilding(building, DIRECTION.TOP, POSITION_TYPE.CENTER, true, false);
                    currentTile.AddBuilding(building, DIRECTION.BOTTOM, POSITION_TYPE.CENTER, false, false);
                }
                break;
            case BUILDING_TYPE.SATELLITE:
                tile.AddBuilding(building, DIRECTION.CENTER, POSITION_TYPE.LEFT, true, false);
                currentTile.AddBuilding(building, DIRECTION.CENTER, POSITION_TYPE.RIGHT, false, false);
                break;

        }
        
    }

    private void AddOutBuilding()
    {

    }
}
