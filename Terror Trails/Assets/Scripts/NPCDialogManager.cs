using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

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

    public void Talk(DialogID dialogID)
    {
        NPCDialogData npcDialog = npcDialogs.Find(d => d.dialogID == dialogID);
        dialogBoxText.text = npcDialogs[(int)dialogID].dialogText;
    }
}
