using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public TMP_Text nameText;
    //public Text oldText;
    public TMP_Text dialogText;
    public Button acceptButton;
    public TMP_Text acceptText;
    public Button rejectButton;
    public TMP_Text rejectText;
    
    /*public Button nextButton;
    public TMP_Text nextText;
    public Button prevButton;
    public TMP_Text prevText;*/
    
    [NonSerialized] public DialogText conversationText;

    public void SetUpDialog(DialogText text)
    {
        conversationText = text;
        dialogText.text = conversationText.GoToPage(0);
    }
    
    public void NextPage()
    {
        if(conversationText == null) return; //if no Dialog script, exit without doing anything
        dialogText.text = conversationText.TurnToNextPage();
    }
    
    public void PrevPage()
    {
        if(conversationText == null) return; //if no Dialog script, exit without doing anything
        dialogText.text = conversationText.TurnToPrevPage();
    }
}
