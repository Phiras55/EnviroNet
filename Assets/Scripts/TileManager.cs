using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TILE_TYPE : byte
{
    TILE_1,
    TILE_2,
    TILE_3
}

public class TileManager : MonoBehaviour
{
    [SerializeField] private List<TILE_TYPE> tileTypes;
    [SerializeField] private List<Tile>      tiles;

    public Tile GetPrefab(TILE_TYPE type)
    {
        int idx = tileTypes.IndexOf(type);

        if (idx >= 0)
        {
            return tiles[idx];
        }
        return tiles[0];
    }
}
