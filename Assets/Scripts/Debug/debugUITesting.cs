using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugUITesting : MonoBehaviour
{

    PlayerUIManager uimanage;

    private void Start()
    {
        
        uimanage = FindObjectOfType<PlayerUIManager>();

    }

    //Made to test UI functions
    public void UIFun(int function)
    {

        switch(function) 
        {

            case (0): //Test screen dim, which is very rough due to the instant appearance of the dim but can clean up UI stuffs later
                uimanage.DimScreen();
                break;

            case (1): //Test UI going away for dialouge
                uimanage.PutAwayUI();
                break;

            case (2): //Test all things for dialouge UI
                uimanage.DimScreen();
                uimanage.PutAwayUI();
                uimanage.CallDialougeUI();
                break;

        }

    }
    
}
