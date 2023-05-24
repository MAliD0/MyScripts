using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystemUI : MonoBehaviour
{
    [SerializeField] Transform ActionButtonPrefab;
    [SerializeField] Transform parent;
    [SerializeField] Unit unit;
    List<Transform> UIButtons;
    void Start()
    {
        unit = UnitActionSystem.instance.getUnit();
        UnitActionSystem.instance.OnChoose += CreateUI;
        CreateUI(this, EventArgs.Empty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateUI(object e, EventArgs eventArgs)
    {
        ClearUI();
        foreach (UnitActionBase action in unit.GetActions())
        {
            Transform button = Instantiate(ActionButtonPrefab, parent);
            button.GetComponent<UnitActionUISingle>().setText(action.actionName());
        }
    }

    void ClearUI()
    {
        foreach (Transform button in parent)
        {
            Destroy(button.gameObject);   
        }
    }
}
