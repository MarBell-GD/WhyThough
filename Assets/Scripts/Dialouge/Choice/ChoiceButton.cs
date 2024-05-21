using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceButton : MonoBehaviour
{

    [HideInInspector] public PlayerUIManager uimanage;
    [HideInInspector] public Choice choice;

    private void Start()
    {
        
        uimanage = FindObjectOfType<PlayerUIManager>();

    }

    public void ChoiceMade()
    {

        DialougeManager dialogManage = FindObjectOfType<DialougeManager>();

        switch(choice.consequence)
        {

            case Choice.choiceConsequence.None:
                break;

            case Choice.choiceConsequence.StartNewDialog:
                dialogManage.Syncronize(choice.newDialouge);
                foreach (DialougeEntry entry in choice.newDialouge.dialouges)
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
                //Does nothing for now >.<
                PlayerInventory inv = FindObjectOfType<PlayerInventory>();
                uimanage.ChoicesBegone();
                dialogManage.DisplayNextEntry();
                break;

            case Choice.choiceConsequence.Multiple:
                if (choice.targetEmotion != PlayerEmotions.Emotion.Neutral)
                {

                    PlayerEmotions emotionz = FindObjectOfType<PlayerEmotions>();

                    if(!uimanage.choiceMade)
                        emotionz.EmotionAdjust(choice.targetEmotion, choice.change, choice.subtract);
                }

                if (choice.givenItem != null)
                {

                    //lmao

                }

                if (choice.newDialouge != null)
                {

                    dialogManage.Syncronize(choice.newDialouge);

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
