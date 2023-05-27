using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class A_Interact : MonoBehaviour
{
    public float radius;
    public void Interact(InputAction.CallbackContext context)
    {
        print("enter");
        if (context.canceled) return;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, radius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.tag == "Interactable")
            {
                Debug.Log("Interact");
                collider.GetComponent<IInteractable>().OnUse();
                return;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position, radius);
    }

}
