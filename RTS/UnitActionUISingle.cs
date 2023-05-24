using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitActionUISingle : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI text;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setText(string name)
    {
        text.text = name;
    }
}
