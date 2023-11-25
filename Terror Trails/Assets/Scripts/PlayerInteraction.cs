using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float _interactionRange = 2f;
    [SerializeField] private KeyCode _interactionButton;

    void Update()
    {
        if (Input.GetKeyDown(_interactionButton))
        {
            Collider2D[] nearest = Physics2D.OverlapCircleAll(transform.position, _interactionRange);
            foreach (Collider2D collider in nearest)
            {
                if (collider.TryGetComponent(out IInteractable interactable))
                    interactable.Interact();
            }
        }
    }
}
