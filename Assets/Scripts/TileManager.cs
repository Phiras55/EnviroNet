using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TILE_TYPE : byte
{
    VOID        = 0,
    START       = 1,
    PLAINS      = 2,
    FOREST      = 3,
    MOUNTAINS   = 4,
    LAKE        = 5,
    CITY        = 6,
    END         = 9
}

public class TileManager : MonoBehaviour
{
    [SerializeField] private List<TILE_TYPE> tileTypes;
    [SerializeField] private List<GameObject>tiles;

    public GameObject GetPrefab(TILE_TYPE type)
    {
        int idx = tileTypes.IndexOf(type);

        if (idx >= 0)
        {
            return tiles[idx];
        }
        return tiles[0];
    }
}
