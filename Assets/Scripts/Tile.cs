using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Sprite     sprite;
    [SerializeField] private TILE_TYPE  type;

    private Building       m_inBuilding;
    private Building       m_outBuilding;
    private SpriteRenderer m_imageComponent;

	// Use this for initialization
	public void Start ()
    {
        m_imageComponent = gameObject.GetComponent<SpriteRenderer>();
        if (m_imageComponent)
        {
            m_imageComponent.sprite = sprite;
        }
        else
        {
            m_imageComponent = gameObject.AddComponent<SpriteRenderer>();
            if (m_imageComponent)
            {
                m_imageComponent.sprite = sprite;
            }
        }
    }

    public Building InBuilding
    {
        get { return m_inBuilding; }
    }

    public Building OutBuilding
    {
        get { return m_outBuilding; }
    }

    private bool AddBuilding(Building building, bool inBuilding)
    {
        int idx = building.TileTypes.IndexOf(type);
        if(idx >= 0)
        {
            if (building.Buildable[idx])
            {
                if(inBuilding && !m_inBuilding)
                {
                    m_inBuilding = building;
                    return true;
                }
                else if(!inBuilding && !m_outBuilding)
                {
                    m_outBuilding = building;
                    return true;
                }
            }
        }
        return false;
    }
}
