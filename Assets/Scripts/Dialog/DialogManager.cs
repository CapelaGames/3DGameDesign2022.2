using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [Header ("ID of this Dialog")]
    public string Name;
    
    [Header("Conversation")]
    public DialogText conversationText;
    
    [Space(10)]
    [Header("GUI reference")]
    [Tooltip("Canvas with dialog script attached")]
    [SerializeField] private Transform _dialogGUI;
    
    private Dialog _dialog;
    
    public void BeginDialog()
    {
        _dialog = _dialogGUI.GetComponent<Dialog>();
        if(_dialog == null) return; //if no Dialog script, exit without doing anything
        _dialog.SetUpDialog(conversationText);
        _dialogGUI.gameObject.SetActive(true);
    }
}
