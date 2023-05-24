using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMoveAction : UnitActionBase
{
    Animator animator;
    [SerializeField] private Vector3 target;
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private float turnsSpeed = 2.5f;
    [SerializeField] private int maxWalkRange = 2;
    private Vector3 moveDirect;
    GridPosition prevPos;

    private float stopDistance = 0.1f;

    protected override void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        base.Awake();
    }
    private void Start()
    {
        target = transform.position;
        //prevPos = new GridPosition((int)transform.position.x, (int)transform.position.z);
    }


    void Update()
    {
        if (!IsTriggered) { return;}
        if (Vector3.Distance(transform.position, target) > stopDistance)
        {
            moveDirect = (target - transform.position).normalized;
            transform.position += moveDirect * Time.deltaTime * speed;
            transform.forward = Vector3.Lerp(transform.forward, moveDirect, Time.deltaTime * turnsSpeed);
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
            base.Disable();
            onInteractionEnd();
        }
    }

    public List<GridPosition> FindValidCells()
    {
        List<GridPosition> avaiblePos = new List<GridPosition>();
        for (int i = -maxWalkRange; i <= maxWalkRange; i++)
        {
            for (int z = -maxWalkRange; z <= maxWalkRange; z++)
            {
                GridPosition validPos = new GridPosition(i, z);
                validPos = LevelGrid.instance.GetGridPos(transform.position)+ validPos;
                if (LevelGrid.instance.CanBeAccessed(validPos) && LevelGrid.instance.GetUnitAtCell(validPos).Count == 0)
                {
                    Debug.Log(validPos);
                    avaiblePos.Add(validPos);
                }
                else { continue; }
                
            }
        }
        return avaiblePos;
    }
    
    private void SetPos(GridPosition target)
    {
        Debug.Log("Target: "+target);
        List<GridPosition> avaiblePos = FindValidCells();
        Debug.Log(avaiblePos.Contains(target));
        if (avaiblePos.Contains(target)) 
        {
            this.target = LevelGrid.instance.GetWorldPos(new Vector3(target.getX(), 0, target.getZ()));
        }

    }

    public void StartAction(Action onInteractionEnd, GridPosition target) 
    {
        this.onInteractionEnd = onInteractionEnd;
        SetPos(target);
        base.Enable();
    }

    public override string actionName()
    {
        return "Move";
    }
}
