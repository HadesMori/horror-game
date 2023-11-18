using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private KeyCode interactionButton;
    private PlayerMovement playerMovement;
    private IInteractable interactable;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        InteractWith();
    }

    private void InteractWith()
    {
        if (Input.GetKeyDown(interactionButton) && interactable != null)
        {
            interactable.Interact();
            playerMovement.SwitchMoveState();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.TryGetComponent(out interactable);
        interactable.ShowHint();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactable.HideHint();
        interactable = null;
    }
}
