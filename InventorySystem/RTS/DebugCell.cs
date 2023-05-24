using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DebugCell : MonoBehaviour
{

    Cell cell;
    [SerializeField] private TextMeshPro text;
    public void SetInfo(Cell cell)
    {
        this.cell = cell;
    }
    private void Update()
    {
        text.text = this.cell.ToString();
    }


}
