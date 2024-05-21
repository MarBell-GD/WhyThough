using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceButton : MonoBehaviour
{

    //This script goes in the buttons for the choice UI and shouldn't be edited now, it works as is

    [HideInInspector] public PlayerUIManager uimanage;
    [HideInInspector] public Choice choice;

    private void Start()
    {
        
        uimanage = FindObjectOfType<PlayerUIManager>();

    }

    public void ChoiceMade()
    {

        DialougeManager dialogManage = FindObjectOfType<DialougeManager>();

        switch(choice.consequence) //i love switch cases
        {

            case Choice.choiceConsequence.None:
                break;

            case Choice.choiceConsequence.StartNewDialog:
                dialogManage.Syncronize(choice.newDialouge); //<=== explained in the inherited script
                foreach (DialougeEntry entry in choice.newDialouge.dialouges) 
                    //Puts all the dialogue in the current one
                {

                    if(!uimanage.choiceMade)
                    {

                        dialogManage.DialogueSentences.Enqueue(entry);

                    }

                }
                uimanage.ChoicesBegone();
                break;

            case Choice.choiceConsequence.ChangeEmotion:
                PlayerEmotions emotions = FindObjectOfType<PlayerEmotions>();
                if (!uimanage.choiceMade)
                    emotions.EmotionAdjust(choice.targetEmotion, choice.change, choice.subtract);
                uimanage.ChoicesBegone();
                dialogManage.DisplayNextEntry();
                break;

            case Choice.choiceConsequence.GiveItem:
                //Still does nothing for now >.<
                PlayerInventory inv = FindObjectOfType<PlayerInventory>();
                uimanage.ChoicesBegone();
                dialogManage.DisplayNextEntry();
                break;

            case Choice.choiceConsequence.Multiple:
                if (choice.targetEmotion != PlayerEmotions.Emotion.Neutral)
                {

                    PlayerEmotions emotionz = FindObjectOfType<PlayerEmotions>(); //Emotions, but COOL

                    if(!uimanage.choiceMade)
                        emotionz.EmotionAdjust(choice.targetEmotion, choice.change, choice.subtract);
                }

                if (choice.givenItem != null)
                {

                    //lmao
                    //me when I'm lazy

                }

                if (choice.newDialouge != null)
                {

                    dialogManage.Syncronize(choice.newDialouge); //<=== explained in the inherited script

                    //Check above for explanation on this
                    foreach (DialougeEntry entry in choice.newDialouge.dialouges)
                    {

                        if (!uimanage.choiceMade)
                            dialogManage.DialogueSentences.Enqueue(entry);

                    }

                    uimanage.ChoicesBegone();

                }
                else if (choice.newDialouge == null)
                    dialogManage.DisplayNextEntry();
                break;

        }

    }

}
