using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class A_Rotate : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void HangleRotation(bool isMoving, float horizontal)
    {
        if (isMoving)
        {
            spriteRenderer.flipX = horizontal > 0;
        }
    }

}
