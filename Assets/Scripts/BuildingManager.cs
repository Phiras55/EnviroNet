using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BUILDING_TYPE : byte
{
    CABLE       = 1,
    WIFI        = 2,
    LASER       = 3,
    SATELLITE   = 4
}

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private List<BUILDING_TYPE> buildingTypes;
    [SerializeField] private List<GameObject>    buildings;

    public GameObject GetPrefab(ref BUILDING_TYPE type)
    {
        int idx = buildingTypes.IndexOf(type);

        if(idx >= 0)
        {
            return buildings[idx];
        }
        return buildings[0];
    }
}
