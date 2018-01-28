using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action
{
    private Vector2 m_src;
    private Vector2 m_dest;
    private Building m_buildingSrc;
    private Building m_buildingDest;

    public Action(Vector2 src, Vector2 dest, Building bSrc, Building bDest)
    {
        m_src = src;
        m_dest = dest;
        m_buildingSrc = bSrc;
        m_buildingDest = bDest;
    }

    public Vector2 Source
    {
        get { return m_src; }
    }

    public Vector2 Destination
    {
        get { return m_dest; }
    }

    public Building BuildingSource
    {
        get { return m_buildingSrc; }
    }

    public Building BuildingDestination
    {
        get { return m_buildingDest; }
    }
}
