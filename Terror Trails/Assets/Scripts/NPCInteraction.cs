using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private GameObject buttonHint;
    private PlayerInteraction playerInteraction;
    private NPCDialogManager npcDialogManager;
    private bool isDialogActive;

    private void Awake()
    {
        isDialogActive = false;
        npcDialogManager = GetComponent<NPCDialogManager>();
        playerInteraction = GameObject.Find("Player").GetComponent<PlayerInteraction>();
    }

    private void Update()
    {
        dialogBox.SetActive(isDialogActive);
    }

    public void Interact()
    {
        isDialogActive = !isDialogActive;

        npcDialogManager.Talk(NPCDialogManager.DialogID.Question);
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
