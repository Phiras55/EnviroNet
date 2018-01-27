using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BUILDING_TYPE : byte
{
    BUILDING_1,
    BUILDING_2,
    BUILDING_3
}

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private List<BUILDING_TYPE> buildingTypes;
    [SerializeField] private List<Building>      buildings;

    public Building GetPrefab(ref BUILDING_TYPE type)
    {
        int idx = buildingTypes.IndexOf(type);

        if(idx >= 0)
        {
            return buildings[idx];
        }
        return buildings[0];
    }


}
