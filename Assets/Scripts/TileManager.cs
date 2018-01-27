using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TILE_TYPE : byte
{
    PLAINS      = 1,
    FOREST      = 2,
    MOUNTAINS   = 3,
    LAKE        = 4,
    CITY        = 5,
    VOID        = 6
}

public class TileManager : MonoBehaviour
{
    [SerializeField] private List<TILE_TYPE> tileTypes;
    [SerializeField] private List<GameObject>tiles;

    public GameObject GetPrefab(ref TILE_TYPE type)
    {
        int idx = tileTypes.IndexOf(type);

        if (idx >= 0)
        {
            return tiles[idx];
        }
        return tiles[0];
    }
}
