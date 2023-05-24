using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public Camera camera;
    [SerializeField] LayerMask mouseInter;
    private static MouseController mouseController;
    void Awake()
    {
        mouseController = this;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static RaycastHit MakeShot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, mouseController.mouseInter);
        return raycastHit;
    }


}
