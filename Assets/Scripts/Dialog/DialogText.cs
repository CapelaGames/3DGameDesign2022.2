using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialog/Text")]
public class DialogText : ScriptableObject
{
    private int currentPageNumber = 0;
    
    [TextArea(3,10)]
    public List<string> conversationText;


    public string CurrentPage()
    {
        return conversationText[currentPageNumber];
    }

    public string TurnToNextPage()
    {
        currentPageNumber++;
        currentPageNumber = Mathf.Min(currentPageNumber, conversationText.Count - 1);
        return CurrentPage();
    }
    
    public string TurnToPrevPage()
    {
        currentPageNumber--;
        currentPageNumber = Mathf.Max(currentPageNumber, 0);
        return CurrentPage();
    }
    
    public string GoToPage(int pageNumber)
    {
        currentPageNumber = pageNumber;
        return CurrentPage();
    }
}
