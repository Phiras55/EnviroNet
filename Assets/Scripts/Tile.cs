using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    [SerializeField] private Sprite sprite;

    private Building m_inBuilding;
    private Building m_outBuilding;
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
        set { m_inBuilding = value; }
    }

    public Building OutBuilding
    {
        get { return m_outBuilding; }
        set { m_outBuilding = value; }
    }
}
