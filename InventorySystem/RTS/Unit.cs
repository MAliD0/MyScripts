using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    GridPosition prevPos;
    UnitMoveAction moveAction;
    UnitTestAction testAction;
    UnitActionBase[] actions;
    private void Awake()
    {
        moveAction = GetComponent<UnitMoveAction>();
        testAction = GetComponent<UnitTestAction>();
        actions = GetComponents<UnitActionBase>();
    }
    private void Start()
    {

        prevPos = new GridPosition((int)transform.position.x, (int)transform.position.z);
        //LevelGrid.instance.AddUnitAtCell(LevelGrid.instance.GetGridPos(transform.position), this);
    }


    void Update()
    {
        GridPosition newPos = LevelGrid.instance.GetGridPos(transform.position);

        if (prevPos != newPos)
        {
            LevelGrid.instance.ChangeUnitPosAtCell(prevPos, newPos, this);
            
            prevPos = newPos;
        }

    }

    public UnitMoveAction GetMoveAction()
    {
        return moveAction;
    }

    public UnitTestAction GetTestAction()
    {
        return testAction;
    }

    public UnitActionBase[] GetActions()
    {
        return actions;
    }
}
