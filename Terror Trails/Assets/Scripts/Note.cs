using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Note : MonoBehaviour, IInteractable
{
    [SerializeField] private string text;
    [SerializeField] private GameObject noteCanvas;
    [SerializeField] private GameObject buttonHint;
    private TextMeshProUGUI textMesh;
    private bool isOpen = false;

    private void Start()
    {
        textMesh = noteCanvas.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Interact()
    {
        isOpen = !isOpen;
        textMesh.text = text;
        noteCanvas.SetActive(isOpen);
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
