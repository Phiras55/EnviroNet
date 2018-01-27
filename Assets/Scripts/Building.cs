using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    [SerializeField] private Sprite          sprite;
    [SerializeField] private BUILDING_TYPE   type;

    [Header("Losts settings")]
    [SerializeField] private List<TILE_TYPE> tileType;
    [SerializeField] private List<float>     losts;
    [SerializeField] private List<bool>      buildable;

    private SpriteRenderer  m_imageComponent;

	// Use this for initialization
	private void Start ()
    {
        m_imageComponent = gameObject.GetComponent<SpriteRenderer>();
        if(m_imageComponent)
        {
            m_imageComponent.sprite = sprite;
        }
        else
        {
            m_imageComponent = gameObject.AddComponent<SpriteRenderer>();
            if(m_imageComponent)
            {
                m_imageComponent.sprite = sprite;
            }
        }
	}

    public List<TILE_TYPE> TileTypes
    {
        get { return tileType; }
    }

    public List<float> Losts
    {
        get { return losts; }
    }

    public List<bool> Buildable
    {
        get { return buildable; }
    }

    public float GetLost(ref TILE_TYPE type)
    {
        int idx = tileType.IndexOf(type);

        if(idx >= 0)
        {
            return losts[idx];
        }
        return 0.0f;
    }
}
