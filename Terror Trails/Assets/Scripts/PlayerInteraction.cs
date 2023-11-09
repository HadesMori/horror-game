using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionRange = 2f;
    [SerializeField] private KeyCode interactionButton;

    void Update()
    {
        if (Input.GetKeyDown(interactionButton))
        {
            Collider2D[] nearest = Physics2D.OverlapCircleAll(transform.position, interactionRange);
            foreach (Collider2D collider in nearest)
            {
                if (collider.TryGetComponent(out IInteractable interactable))
                {
                    interactable.Interact();
                }
            }
        }
    }
}
