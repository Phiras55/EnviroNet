using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] int         LevelNumber;
    [SerializeField] TileManager tileManager;
    [SerializeField] BuildingManager    buildingManager;
    [SerializeField] Vector2     gameZoneOffset;
    public Building currentBuilding;
    Tile currentTile;
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

        GameObject test1 = Instantiate(buildingManager.GetPrefab(BUILDING_TYPE.LASER));
        GameObject test2 = Instantiate(buildingManager.GetPrefab(BUILDING_TYPE.LASER));
        GameObject test3 = Instantiate(buildingManager.GetPrefab(BUILDING_TYPE.LASER));
        Tiles[0].GetComponent<Tile>().AddBuilding(test2.GetComponent<Building>(), DIRECTION.LEFT, POSITION_TYPE.CENTER, true, false);
        Tiles[0].GetComponent<Tile>().AddBuilding(test1.GetComponent<Building>(), DIRECTION.RIGHT, POSITION_TYPE.RIGHT, false, false);
        Tiles[1].GetComponent<Tile>().AddBuilding(test3.GetComponent<Building>(), DIRECTION.LEFT, POSITION_TYPE.RIGHT, true, false);

        Tiles[0].GetComponent<Tile>().RemoveBuilding(true);
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
            Debug.Log("toto");
            return Tiles[y * paterns.SIZE_X + x].GetComponent<Tile>();
        }
        return null;
    }

    public Tile FindTile()
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, 
                        Input.mousePosition.y, 
                        Camera.main.nearClipPlane));

        return GetTile((int)point.x/128, (int)paterns.SIZE_Y - (int)point.y/128);
    }

    public void OnMouseDown()
    {
        if(!clicked)
        {
            clicked = true;
            Debug.Log(FindTile().gameObject.transform.position);
        }
    }
    public void OnMouseUp()
    {
        clicked = false;
    }
}
