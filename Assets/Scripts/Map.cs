using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    const int SIZE_X = 9;
    const int SIZE_Y = 7;

    //Ints will match the tile enum

    //Change int by the tile class when done
    int[,] Tiles;

	void Start ()
    {
        Tiles = new int[SIZE_X,SIZE_Y];
        //Populate the map with patern
        int[,] currentLevel = paterns;
        for (int y = 0; y < SIZE_Y; y++)
        {
            for (int x = 0; x < SIZE_X; x++)
            {
                //Tiles[x,y] = Instantiate(GetTile(paterns.Levels[x,y]))
                //Tiles[x,y].transform.position = new Vector3(x*128, y*128, 0);
            }
        }
	}
	
	void Update ()
    {
		
	}
}
