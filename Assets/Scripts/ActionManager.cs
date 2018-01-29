using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    private Map          m_map;
    private List<Action> m_pastActions;
    private List<Action> m_futureAction;

    private void Start()
    {
        m_pastActions = new List<Action>();

        GameObject gMap = GameObject.FindGameObjectWithTag("Map");
        if(gMap)
        {
            m_map = gMap.GetComponent<Map>();
        }
    }

    private Action GetLastAction()
    {
        if (isUndoEmpty())
            return null;

        return m_pastActions[m_pastActions.Count - 1];
    }

    public bool isRedoEmpty()
    {
        return m_futureAction.Count == 0;
    }

    public bool isUndoEmpty()
    {
        return m_pastActions.Count == 0;
    }

    public void AddAction(Vector2 src, Vector2 dest, Building bSrc, Building bDest)
    {
        m_pastActions.Add(new Action(src, dest, bSrc, bDest));
        Debug.Log("Action added.");
    }

    public void Undo()
    {
        Action lastAction = GetLastAction();

        if(!lastAction.Equals(null))
            return;

        Action copyLastAction = lastAction;
        Tile destTile = m_map.GetTile((int)lastAction.Destination.x, (int)lastAction.Destination.y);
        Tile srcTile = m_map.GetTile((int)lastAction.Source.x, (int)lastAction.Source.y);

        m_futureAction.Add(copyLastAction);

        if (!destTile || !srcTile)
            return;

        destTile.RemoveBuilding(true);
        srcTile.RemoveBuilding(false);
    }

    public void Redo()
    {

    }
}
