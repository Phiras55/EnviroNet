using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSelector : MonoBehaviour {

    [SerializeField] Map map;
    [SerializeField] Building building;

    public void SetCurrentBuilding()
    {
        map.currentBuilding = building;
    }

}
