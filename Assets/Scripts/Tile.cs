using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private TILE_TYPE type;

    private Building m_inBuilding;
    private Building m_outBuilding;
    private SpriteRenderer m_imageComponent;

    // Use this for initialization
    public void Start()
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

    public TILE_TYPE Type
    {
        get { return type; }
    }

    public bool AddBuilding(Building building, DIRECTION dir, POSITION_TYPE posType, bool inBuilding, bool continous)
    {
        int idx = building.TileTypes.IndexOf(type);
        if (idx >= 0)
        {
            if (building.Buildable[idx])
            {
                if (inBuilding && !m_inBuilding)
                {
                    if (continous)
                        building.SwitchToContinuousSprite();
                    m_inBuilding = building;
                    PositionBuilding(m_inBuilding, dir, posType);
                    return true;
                }
                else if (!inBuilding && !m_outBuilding)
                {
                    if (continous)
                        building.SwitchToContinuousSprite();
                    m_outBuilding = building;
                    PositionBuilding(m_outBuilding, dir, posType);
                    return true;
                }
            }
        }
        return false;
    }

    public bool RemoveBuilding(bool inBuilding)
    {
        if(inBuilding && m_inBuilding)
        {
            Destroy(m_inBuilding.gameObject);
            return true;
        }
        else if(!inBuilding && m_outBuilding)
        {
            Destroy(m_outBuilding.gameObject);
            return true;
        }
        return false;
    }

    private void PositionBuilding(Building building, DIRECTION dir, POSITION_TYPE posType)
    {
        // Tile is      TOP LEFT
        // Building is  CENTER
        Vector3 offset = new Vector3(64, -64, -0.5f);
        
        if(dir == DIRECTION.CENTER)
        {
            if(posType == POSITION_TYPE.CENTER)
            {
            }
            else if(posType == POSITION_TYPE.LEFT)
            {
                offset.x = building.SpriteSize.x / 2.0f;
            }
            else if (posType == POSITION_TYPE.RIGHT)
            {
                offset.x = 128 - building.SpriteSize.x / 2.0f;
            }
        }
        else if(dir == DIRECTION.TOP_LEFT)
        {
            building.transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), 90.0f);
        }
        else if(dir == DIRECTION.TOP)
        {
            building.transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), 270.0f);
        }
        else if (dir == DIRECTION.TOP_RIGHT)
        {
        }
        else if (dir == DIRECTION.LEFT)
        {
        }
        else if (dir == DIRECTION.RIGHT)
        {
            building.transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), 180.0f);
        }
        else if (dir == DIRECTION.BOTTOM_LEFT)
        {
            building.transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), 180.0f);
        }
        else if(dir == DIRECTION.BOTTOM)
        {
            building.transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), 90.0f);
        }
        else if (dir == DIRECTION.BOTTOM_RIGHT)
        {
            building.transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), 270.0f);
        }

        building.transform.position = transform.position + offset;
    }
}
