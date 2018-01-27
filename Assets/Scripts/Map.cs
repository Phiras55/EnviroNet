using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] int LevelNumber;
    Level paterns;
    TileManager tileManager;


    //Change int by the tile class when done
    List<GameObject> Tiles;

	void Start ()
    {
        paterns = new Level();
        byte[,] currentLevel = new byte[paterns.SIZE_X, paterns.SIZE_Y];
        currentLevel = paterns.Levels[LevelNumber];
        currentLevel = paterns.Levels[LevelNumber];
        //Populate the map with patern
        for (int y = 0; y < paterns.SIZE_Y; y++)
        {
            for (int x = 0; x < paterns.SIZE_X; x++)
            {
                Debug.Log(tileManager.GetPrefab(((TILE_TYPE)(currentLevel[x, y]))));
                Tiles[y * paterns.SIZE_X + x] = Instantiate(tileManager.GetPrefab(((TILE_TYPE)(currentLevel[x,y]))).gameObject);
                Tiles[y* paterns.SIZE_X + x].transform.position = new Vector3(x*128, y*128, 0);
            }
        }
	}
	
	void Update ()
    {
		
	}
}
