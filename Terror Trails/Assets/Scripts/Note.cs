using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Note : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject noteCanvas;
    [SerializeField] private string text;
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
}
