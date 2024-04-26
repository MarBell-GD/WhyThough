using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamineClick : MonoBehaviour
{

    PlayerUIManager uimanage;

    // Start is called before the first frame update
    void Start()
    {

        uimanage = FindObjectOfType<PlayerUIManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
        //freaky code

    }

    public void OnClick()
    {

        if (!uimanage.isExamining && !uimanage.isDialouge && !uimanage.isStatus)
            uimanage.OpenExamineUI();
        else if (uimanage.isExamining)
            uimanage.CloseExamineUI();

    }

}
