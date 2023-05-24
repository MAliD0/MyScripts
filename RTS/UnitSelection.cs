using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private Unit unit;
    [SerializeField] private LayerMask Unit;
    public static UnitSelection instance;
    void Awake()
    {
        instance = this;
    }



}
