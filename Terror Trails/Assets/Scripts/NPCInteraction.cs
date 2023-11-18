using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private GameObject buttonHint;
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

    public void ShowHint()
    {
        buttonHint.SetActive(true);
    }

    public void HideHint()
    {
        buttonHint.SetActive(false);
    }
}
