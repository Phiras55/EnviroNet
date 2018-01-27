using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    [SerializeField] private Sprite          sprite;
    [SerializeField] private List<TILE_TYPE> tileType;
    [SerializeField] private List<float>     losts;

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
