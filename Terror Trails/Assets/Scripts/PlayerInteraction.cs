using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private KeyCode _interactionButton;
    private PlayerMovement _playerMovement;
    private IInteractable _interactable;
    private List<Collider2D> _intColliders = new List<Collider2D>();


    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        Interact();
    }

    private void Interact()
    {
        if (Input.GetKeyDown(_interactionButton) && _intColliders.Count > 0)
        {
            int lastCollider = _intColliders.Count - 1;
            _intColliders[lastCollider].TryGetComponent(out _interactable);
            _interactable.Interact();
            _playerMovement.SwitchMoveState();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _intColliders.Add(collision);
        collision.TryGetComponent(out _interactable);
        if(_interactable != null)
        {
            _interactable.ShowHint();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _intColliders.Remove(collision);
        collision.TryGetComponent(out _interactable);
        if(_interactable != null)
        {
            _interactable.HideHint();
        }
    }
}
