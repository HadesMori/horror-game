using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject dialogBox;
    private bool isDialogActive;

    private void Awake()
    {
        isDialogActive = false;
    }

    public void Interact()
    {
        isDialogActive = !isDialogActive;
        dialogBox.SetActive(isDialogActive);
    }
}
