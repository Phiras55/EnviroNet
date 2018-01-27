using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] int LevelNumber;
    [SerializeField] TileManager tileManager;
    [SerializeField] Vector2 gameZoneOffset;
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
        for (int y = 0; y < paterns.SIZE_Y; y++)
        {
            for (int x = 0; x < paterns.SIZE_X; x++)
            {
                GameObject currentTile = Instantiate(tileManager.GetPrefab(((TILE_TYPE)(currentLevel[y,x]))));
                currentTile.transform.position = new Vector3(x*128+gameZoneOffset.x, y*128+gameZoneOffset.y, 0);
                Tiles.Add(currentTile);
            }
        }
	}
	
	void Update ()
    {
		
	}
}
