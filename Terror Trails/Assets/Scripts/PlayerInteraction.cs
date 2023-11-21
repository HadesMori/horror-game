using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private KeyCode interactionButton;
    private PlayerMovement playerMovement;
    private IInteractable interactable;
    private List<Collider2D> intColliders = new List<Collider2D>();

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        Interact();
    }

    private void Interact()
    {
        if (Input.GetKeyDown(interactionButton) && intColliders.Count > 0)
        {
            int lastCollider = intColliders.Count - 1;
            intColliders[lastCollider].TryGetComponent(out interactable);
            interactable.Interact();
            playerMovement.SwitchMoveState();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        intColliders.Add(collision);
        collision.TryGetComponent(out interactable);
        interactable.ShowHint();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        intColliders.Remove(collision);
        collision.TryGetComponent(out interactable);
        interactable.HideHint();
    }
}
