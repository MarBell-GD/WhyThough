using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickInteract : MonoBehaviour
{

    //ripped from my code for games work with some modifs for this game
    [HideInInspector] public PlayerUIManager uimanage;
    [HideInInspector] public PlayerEmotions emotions;

    // Start is called before the first frame update
    void Start()
    {
        
        uimanage = FindObjectOfType<PlayerUIManager>();
        emotions = FindObjectOfType<PlayerEmotions>();

    }

    // Update is called once per frame
    void Update()
    {

        Ray interact = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(interact, out hit))
        {

            if (Input.GetKeyDown(KeyCode.Mouse0) && !uimanage.cantMove)
            {

                if(hit.collider.GetComponent<DialougeTrigger>() != null && !uimanage.isDialouge)
                {

                    CheckDialougeCondition(hit.collider.GetComponent<DialougeTrigger>());

                }

            }

        }

    }

    void CheckDialougeCondition(DialougeTrigger trigger)
    {

        switch(trigger.condition)
        {

            case (DialougeTrigger.Condition.None):
                if(trigger.alternate && !trigger.hasInteracted || !trigger.alternate)
                    trigger.TriggerDialouge();
                else if(trigger.alternate && trigger.hasInteracted)
                    trigger.TriggerAltDialouge();
                break;

            case (DialougeTrigger.Condition.Emotion):
                if(emotions.playerEmotion == trigger.emotionReq && emotions.highestEmo >= trigger.emotionThreshold)
                    trigger.TriggerDialouge();
                else if(trigger.alternate)
                    trigger.TriggerAltDialouge();
                break;

        }

    }

}
