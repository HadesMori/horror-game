using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;

public class NPCDialogManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogBoxText;

    [Serializable]
    public class NPCDialogData
    {
        public DialogID dialogID;
        public string dialogText;
    }

    public enum DialogID
    {
        Greeting,
        Goodbye,
        Question,
    }

    public List<NPCDialogData> npcDialogs = new List<NPCDialogData>();

    private int currentDialogIndex = 0; // Index of the current dialog

    private void Start()
    {
        // Adding text for each item in npcDialogs
        npcDialogs.Add(new NPCDialogData { dialogID = DialogID.Greeting, dialogText = "Hello fckin cunt" });
        npcDialogs.Add(new NPCDialogData { dialogID = DialogID.Goodbye, dialogText = "pispopa" });
        npcDialogs.Add(new NPCDialogData { dialogID = DialogID.Question, dialogText = "Go fuckyourself" });
    }

    public void Talk(DialogID dialogID)
    {
        NPCDialogData npcDialog = npcDialogs.Find(d => d.dialogID == dialogID);
        dialogBoxText.text = npcDialog.dialogText;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Logic for displaying the next dialog
            currentDialogIndex++;
            if (currentDialogIndex < npcDialogs.Count)
            {
                dialogBoxText.text = npcDialogs[currentDialogIndex].dialogText;
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            // Logic for exiting the dialog
            dialogBoxText.text = string.Empty; // Clearing the dialog text field
        }
    }
}
