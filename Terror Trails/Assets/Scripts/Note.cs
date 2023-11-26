using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Note : MonoBehaviour, IInteractable
{

    [SerializeField] private GameObject _buttonHint;
    [SerializeField] private GameObject _noteCanvas;
    [SerializeField] private string _text;
    private TextMeshProUGUI _textMesh;
    private bool _isOpen = false;


    private void Start()
    {
        _textMesh = _noteCanvas.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Interact()
    {
        _isOpen = !_isOpen;
        _textMesh.text = _text;
        _noteCanvas.SetActive(_isOpen);
    }

    public void ShowHint()
    {
        _buttonHint.SetActive(true);
    }

    public void HideHint()
    {
        _buttonHint.SetActive(false);
    }
}
